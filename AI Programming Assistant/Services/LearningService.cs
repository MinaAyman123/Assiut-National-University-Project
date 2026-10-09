using System.Text.Json;
using AI_Programming_Assistant.Models;

namespace AI_Programming_Assistant.Services
{
    public interface ILearningService
    {
        Task<Language> GenerateLanguageLevels(string languageName);
        Task<Level> GetLevelContent(string language, int levelNumber);
        Task<Quiz> GenerateQuiz(string language, int levelNumber, string levelContent);
        Task<bool> SaveProgress(UserProgress progress);
        Task<UserProgress?> LoadProgress(string language);
        bool CheckQuizPass(Quiz quiz, List<int> userAnswers);
    }

    public class LearningService : ILearningService
    {
        private readonly IOllamaService _ollama;
        private readonly string _progressPath = "UserProgress";

        public LearningService(IOllamaService ollama)
        {
            _ollama = ollama;
            if (!Directory.Exists(_progressPath)) Directory.CreateDirectory(_progressPath);
        }

        public async Task<Language> GenerateLanguageLevels(string languageName)
        {
            var levels = new List<Level>();
            for (int i = 1; i <= 15; i++)
            {
                levels.Add(new Level
                {
                    LevelNumber = i,
                    Title = i == 1 ? "المقدمة والأساسيات" : i == 2 ? "المتغيرات والبيانات" : i == 3 ? "الجمل الشرطية" : i == 4 ? "الحلقات" : i == 5 ? "الدوال" : $"المستوى {i}",
                    Description = $"تعلم مفاهيم المستوى {i} في {languageName}",
                    IsUnlocked = i == 1,
                    IsCompleted = false
                });
            }
            return new Language { Name = languageName, Levels = levels };
        }

        public async Task<Level> GetLevelContent(string language, int levelNumber)
        {
            var prompt = $@"You are a teacher. Explain level {levelNumber} of {language} in ARABIC.
Use HTML with these classes: lesson-section, text-cyan-400, text-gray-300.
Include code in <pre><code>.
Write a detailed explanation.

شرح المستوى {levelNumber} في {language}:";

            var content = await _ollama.GenerateResponse(prompt);
            if (string.IsNullOrEmpty(content) || content.StartsWith("خطأ") || content.Contains("⚠️"))
            {
                content = GetDefaultContent(language, levelNumber);
            }

            return new Level
            {
                LevelNumber = levelNumber,
                Content = content,
                Title = $"المستوى {levelNumber}",
                Description = $"تعلم المستوى {levelNumber} في {language}"
            };
        }

        // ✅ الدالة الصحيحة - تولد أسئلة من الـ LLM على المحتوى
        public async Task<Quiz> GenerateQuiz(string language, int levelNumber, string levelContent)
        {
            var quiz = new Quiz();

            // خذ المحتوى كاملاً أو أول 3000 حرف
            var contentSample = levelContent.Length > 3000 ? levelContent.Substring(0, 3000) : levelContent;

            if (string.IsNullOrEmpty(contentSample) || contentSample.Length < 50)
            {
                contentSample = $"محتوى المستوى {levelNumber} في لغة {language} يشرح المفاهيم الأساسية.";
            }

            // ✅ الـ Prompt اللي بيخلي الـ LLM يولد أسئلة على المحتوى
            var prompt = $@"Based ONLY on the educational content below about {language} (Level {levelNumber}), create a 10-question quiz.

IMPORTANT - استخدم المحتوى فقط:
1. خصص الأسئلة على المعلومات الموجودة في المحتوى أدناه
2. كل سؤال له 4 خيارات
3. إجابة واحدة صحيحة لكل سؤال
4. اشرح الإجابة من المحتوى نفسه
5. أخرج JSON فقط بدون نص إضافي
6. استخدم اللغة العربية

المحتوى:
{contentSample}

الخرج المطلوب (JSON فقط):
{{
    ""questions"": [
        {{
            ""question"": ""السؤال"",
            ""options"": [""خيار1"", ""خيار2"", ""خيار3"", ""خيار4""],
            ""correctAnswer"": 0,
            ""explanation"": ""الشرح من المحتوى""
        }}
    ]
}}

أخرج 10 أسئلة JSON فقط:";

            var response = await _ollama.GenerateResponse(prompt);
            var parsedQuiz = ParseQuizFromResponse(response);

            // لو الـ LLM مردش أسئلة، حاول مرة تانية بـ Prompt أقصر
            if (parsedQuiz.Questions == null || parsedQuiz.Questions.Count < 10)
            {
                var shortPrompt = $@"From this {language} lesson content, create 10 ARABIC questions in JSON:

Content: {contentSample.Substring(0, Math.Min(1000, contentSample.Length))}

Output: {{ ""questions"": [{{ ""question"": """", ""options"": [""a"",""b"",""c"",""d""], ""correctAnswer"": 0, ""explanation"": """" }}] }}";

                var retryResponse = await _ollama.GenerateResponse(shortPrompt);
                parsedQuiz = ParseQuizFromResponse(retryResponse);
            }

            // لو لسه مفيش أسئلة، معناها الـ LLM مش شغال - اعرض error للمستخدم
            if (parsedQuiz.Questions == null || parsedQuiz.Questions.Count == 0)
            {
                quiz.Questions = new List<QuizQuestion>
                {
                    new QuizQuestion
                    {
                        Question = "⚠️ عذراً، لا يمكن توليد الأسئلة حالياً",
                        Options = new List<string> { "تأكد من تشغيل Ollama", "حاول مرة أخرى", "تحقق من الاتصال", "أعد تحميل الصفحة" },
                        CorrectAnswer = 0,
                        Explanation = "خدمة توليد الأسئلة غير متاحة. يرجى التحقق من تشغيل Ollama."
                    }
                };
                return quiz;
            }

            return parsedQuiz;
        }

        public async Task<bool> SaveProgress(UserProgress progress)
        {
            try
            {
                var fileName = Path.Combine(_progressPath, $"{progress.Language}.json");
                await File.WriteAllTextAsync(fileName, JsonSerializer.Serialize(progress));
                return true;
            }
            catch { return false; }
        }

        public async Task<UserProgress?> LoadProgress(string language)
        {
            try
            {
                var fileName = Path.Combine(_progressPath, $"{language}.json");
                if (File.Exists(fileName))
                {
                    var json = await File.ReadAllTextAsync(fileName);
                    return JsonSerializer.Deserialize<UserProgress>(json);
                }
            }
            catch { }
            return null;
        }

        public bool CheckQuizPass(Quiz quiz, List<int> userAnswers)
        {
            if (userAnswers.Count != quiz.Questions.Count) return false;
            int correct = 0;
            for (int i = 0; i < quiz.Questions.Count; i++)
                if (userAnswers[i] == quiz.Questions[i].CorrectAnswer) correct++;
            return (double)correct / quiz.Questions.Count >= 0.7;
        }

        // ==================== دوال مساعدة ====================

        private Quiz ParseQuizFromResponse(string response)
        {
            var quiz = new Quiz();
            quiz.Questions = new List<QuizQuestion>();

            try
            {
                response = CleanJson(response);
                Console.WriteLine($"Parsing JSON: {response.Substring(0, Math.Min(200, response.Length))}");

                var quizData = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (quizData != null && quizData.ContainsKey("questions"))
                {
                    var questionsJson = JsonSerializer.Serialize(quizData["questions"]);
                    var questions = JsonSerializer.Deserialize<List<QuizQuestion>>(questionsJson);

                    if (questions != null && questions.Count > 0)
                    {
                        quiz.Questions = questions;
                        return quiz;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Parse error: {ex.Message}");
            }

            return quiz;
        }

        private string GetDefaultContent(string language, int levelNumber)
        {
            return $@"
<div class='lesson-section'>
    <h3 class='text-cyan-400 text-xl font-bold mb-4'>المستوى {levelNumber}: {language}</h3>
    <div class='bg-cyan-500/10 border border-cyan-500/30 rounded-lg p-4 mb-4'>
        <h4 class='text-cyan-400 font-bold mb-2'>📌 المفاهيم الأساسية:</h4>
        <ul class='list-disc list-inside text-gray-300'>
            <li>المتغيرات: تستخدم لتخزين البيانات في الذاكرة</li>
            <li>الجمل الشرطية (if/else): تستخدم لاتخاذ القرارات</li>
            <li>الحلقات (for/while): تستخدم لتكرار الأوامر</li>
            <li>الدوال (Functions): مجموعة من الأوامر تؤدي مهمة محددة</li>
        </ul>
    </div>
    <pre class='bg-black/50 p-3 rounded-lg overflow-x-auto'><code class='text-green-400'>// مثال: تعريف متغير وطباعته
string message = ""مرحباً بالعالم"";
Console.WriteLine(message);</code></pre>
</div>";
        }

        private string CleanJson(string json)
        {
            if (string.IsNullOrEmpty(json)) return "{}";
            json = json.Replace("```json", "").Replace("```", "").Trim();
            int start = json.IndexOf('{');
            int end = json.LastIndexOf('}');
            return start >= 0 && end > start ? json.Substring(start, end - start + 1) : json;
        }
    }
}