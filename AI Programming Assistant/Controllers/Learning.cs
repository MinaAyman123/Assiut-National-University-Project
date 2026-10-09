
using AI_Programming_Assistant.Models;
using AI_Programming_Assistant.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AI_Programming_Assistant.Controllers
{
    public class LearningController : Controller
    {
        private readonly AiProgrammingAssistantContext _context;
        private readonly ILearningService _learningService;
        private readonly IOllamaService _ollama;

        public LearningController(
            AiProgrammingAssistantContext context,
            ILearningService learningService,
            IOllamaService ollama)
        {
            _context = context;
            _learningService = learningService;
            _ollama = ollama;
        }

        // ✅ صفحة التعلم الرئيسية
        public IActionResult Learning()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("login_create_account", "login_create_account");

            ViewBag.UserId = userId;
            var model = new LearningSystemViewModel();
            return View(model);
        }

        // ✅ جلب المحتوى (من قاعدة البيانات أو من Ollama)
        [HttpPost]
        public async Task<IActionResult> GetContent([FromBody] LearningRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Language) || request.Level < 1 || request.UserId < 1)
                    return Json(new { success = false, message = "بيانات غير صالحة" });

                Console.WriteLine($"📚 GetContent: {request.Language}, Level {request.Level}");

                // 1. البحث عن اللغة أو إنشاؤها
                var language = await _context.ProgrammingLanguages
                    .FirstOrDefaultAsync(l => l.LanguageName.ToLower() == request.Language.ToLower());

                if (language == null)
                {
                    language = new ProgrammingLanguage { LanguageName = request.Language };
                    _context.ProgrammingLanguages.Add(language);
                    await _context.SaveChangesAsync();
                }

                // 2. جلب تقدم المستخدم
                var userProgress = await _context.UsersProgrammingLanguages
                    .FirstOrDefaultAsync(up => up.UserId == request.UserId && up.LanguageId == language.LanguageId);

                int maxUnlocked = userProgress?.UserLevel ?? 1;

                // 3. البحث عن المحتوى في قاعدة البيانات
                var content = await _context.LearningContents
                    .FirstOrDefaultAsync(c => c.LanguageId == language.LanguageId && c.Level == request.Level);

                // 4. لو المحتوى موجود، ارجعه من قاعدة البيانات
                if (content != null)
                {
                    Console.WriteLine("📦 Content Loaded From Database");
                    return Json(new
                    {
                        success = true,
                        content = content.Content,
                        exam = content.Exam,
                        maxUnlocked = maxUnlocked,
                        title = $"المستوى {request.Level}: {request.Language}"
                    });
                }

                // 5. لو المحتوى مش موجود، ولّده من Ollama
                Console.WriteLine("🤖 Generating Content From Ollama");

                var level = await _learningService.GetLevelContent(request.Language, request.Level);
                string finalContent = FormatContent(level?.Content ?? GetDefaultContent(request.Language, request.Level));

                var quiz = await _learningService.GenerateQuiz(request.Language, request.Level, finalContent);
                var questionsList = quiz.Questions?.Count > 0 ? quiz.Questions : GetDefaultTestQuestions();
                var examJson = JsonSerializer.Serialize(questionsList);

                // حفظ المحتوى في قاعدة البيانات
                content = new LearningContent
                {
                    LanguageId = language.LanguageId,
                    Level = request.Level,
                    Content = finalContent,
                    Exam = examJson
                };

                _context.LearningContents.Add(content);
                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    content = finalContent,
                    exam = examJson,
                    maxUnlocked = maxUnlocked,
                    title = $"المستوى {request.Level}: {request.Language}"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ GetContent Error: {ex.Message}");
                return Json(new { success = false, message = ex.Message });
            }
        }

        // ✅ تحديث تقدم المستخدم
        [HttpPost]
        public async Task<IActionResult> UpdateProgress([FromBody] ProgressRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Language) || request.UserId < 1)
                    return Json(new { success = false, message = "بيانات غير صالحة" });

                var language = await _context.ProgrammingLanguages
                    .FirstOrDefaultAsync(l => l.LanguageName.ToLower() == request.Language.ToLower());

                if (language == null)
                    return Json(new { success = false, message = "اللغة غير موجودة" });

                var progress = await _context.UsersProgrammingLanguages
                    .FirstOrDefaultAsync(up => up.UserId == request.UserId && up.LanguageId == language.LanguageId);

                if (progress == null)
                {
                    progress = new UsersProgrammingLanguage
                    {
                        UserId = request.UserId,
                        LanguageId = language.LanguageId,
                        UserLevel = request.NewLevel
                    };
                    _context.UsersProgrammingLanguages.Add(progress);
                }
                else if (request.NewLevel > progress.UserLevel)
                {
                    progress.UserLevel = request.NewLevel;
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true, newMaxUnlocked = progress.UserLevel });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // ✅ جلب جميع مسارات المستخدم
        [HttpPost]
        public async Task<IActionResult> GetUserCourses([FromBody] UserCoursesRequest request)
        {
            try
            {
                var courses = await _context.UsersProgrammingLanguages
                    .Where(up => up.UserId == request.UserId)
                    .Include(up => up.Language)
                    .Select(up => new
                    {
                        language = up.Language.LanguageName,
                        maxUnlocked = up.UserLevel ?? 1
                    })
                    .ToListAsync();

                return Json(new { success = true, courses });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // ✅ دالة اختبار Ollama
        [HttpGet]
        public async Task<IActionResult> TestOllama()
        {
            try
            {
                var result = await _ollama.GenerateResponse("قل مرحبا");
                return Content($"Ollama رد: {result}");
            }
            catch (Exception ex)
            {
                return Content($"خطأ: {ex.Message}");
            }
        }

        // ✅ دوال مساعدة
        private string FormatContent(string content)
        {
            if (string.IsNullOrEmpty(content)) return content;
            if (!content.Contains("lesson-section"))
                content = $"<div class='lesson-section'>{content}</div>";

            content = Regex.Replace(content, @"```(\w*)\n(.*?)```",
                m => $"<pre class='bg-black/50 p-4 rounded-lg overflow-x-auto my-4'><code class='text-green-400 font-mono text-sm'>{m.Groups[2].Value}</code></pre>",
                RegexOptions.Singleline);
            return content;
        }

        private string GetDefaultContent(string language, int levelNumber)
        {
            return $@"
<div class='lesson-section'>
    <h3 class='text-cyan-400 text-xl font-bold mb-4'>المستوى {levelNumber}: مقدمة في {language}</h3>
    <div class='bg-cyan-500/10 border border-cyan-500/30 rounded-lg p-4 mb-4'>
        <h4 class='text-cyan-400 font-bold mb-2'>📌 ما ستتعلمه:</h4>
        <ul class='list-disc list-inside space-y-1 text-gray-300'>
            <li>المفاهيم الأساسية للغة {language}</li>
            <li>إعداد بيئة التطوير</li>
            <li>أول برنامج لك في {language}</li>
        </ul>
    </div>
    <pre class='bg-black/50 p-3 rounded-lg overflow-x-auto'><code class='text-green-400'>Console.WriteLine(""مرحباً!"");</code></pre>
</div>";
        }

        private List<QuizQuestion> GetDefaultTestQuestions()
        {
            return new List<QuizQuestion>
            {
                new() { Question = "ما هو المقصود بـ Variable في البرمجة؟", Options = new List<string> { "دالة حسابية", "مكان لتخزين البيانات", "حلقة تكرارية", "شرط منطقي" }, CorrectAnswer = 1, Explanation = "المتغير مكان لتخزين البيانات" },
                new() { Question = "أي من التالي يستخدم للتكرار؟", Options = new List<string> { "if", "else", "for", "switch" }, CorrectAnswer = 2, Explanation = "for تستخدم للتكرار" },
                new() { Question = "ما هي وظيفة الـ Function؟", Options = new List<string> { "تخزين البيانات", "تنفيذ مهمة محددة", "ربط قواعد البيانات", "تصميم واجهات" }, CorrectAnswer = 1, Explanation = "الدالة تنفذ مهمة محددة" },
                new() { Question = "ما هو الـ Debugging؟", Options = new List<string> { "كتابة كود", "تصحيح الأخطاء", "تحسين الأداء", "توثيق الكود" }, CorrectAnswer = 1, Explanation = "Debugging هو تصحيح الأخطاء" },
                new() { Question = "ما هو الـ Algorithm؟", Options = new List<string> { "لغة برمجة", "خطوات لحل مشكلة", "نوع بيانات", "أداة تصحيح" }, CorrectAnswer = 1, Explanation = "الخوارزمية خطوات لحل مشكلة" }
            };
        }
    }

    // Request Models
    public class LearningRequest
    {
        public string Language { get; set; } = "";
        public int Level { get; set; }
        public int UserId { get; set; }
    }

    public class ProgressRequest
    {
        public string Language { get; set; } = "";
        public int NewLevel { get; set; }
        public int UserId { get; set; }
    }

    public class UserCoursesRequest
    {
        public int UserId { get; set; }
    }
}