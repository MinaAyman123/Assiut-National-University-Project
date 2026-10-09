using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AI_Programming_Assistant.Services
{
    public interface IOllamaService
    {
        Task<string> GenerateResponse(string prompt, string model = null);
        Task<string> GenerateLeveledExplanation(string language, string level);
        Task<string> GenerateQuiz(string language, string level, string explanationContent);
    }

    public class OllamaService : IOllamaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _ollamaUrl = "http://localhost:11434/api/generate";
        private readonly string _defaultModel = "llama3.2:3b";

        public OllamaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromMinutes(5);
        }

        public async Task<string> GenerateResponse(string prompt, string model = null)
        {
            string modelToUse = model ?? _defaultModel; // "llama3.2:3b"

            var requestBody = new
            {
                model = modelToUse,
                prompt = prompt,
                stream = false,
                options = new { temperature = 0.7, num_predict = 3000 } // زودت num_predict عشان يجيب أسئلة أكثر
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                Console.WriteLine($"📤 Sending to Ollama with model: {modelToUse}");

                var response = await _httpClient.PostAsync(_ollamaUrl, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return $"⚠️ خطأ: {response.StatusCode} - تأكد من الموديل {modelToUse} موجود";
                }

                var result = JsonSerializer.Deserialize<OllamaResponse>(responseString);
                return result?.response ?? "لا يوجد رد من النموذج";
            }
            catch (Exception ex)
            {
                return $"❌ خطأ في الاتصال: {ex.Message}";
            }
        }

        public async Task<string> GenerateLeveledExplanation(string language, string level)
        {
            string levelText = level == "Beginner" ? "مبتدئ" : (level == "Intermediate" ? "متوسط" : "متقدم");

            string prompt = $@"أنت مدرس برمجة محترف. اشرح لغة {language} للمستوى {levelText} باللغة العربية.

المطلوب:
- شرح مفصل ومناسب للمستوى
- أمثلة عملية بسيطة
- أسلوب سهل وواضح

الشرح:";

            return await GenerateResponse(prompt);
        }

        public async Task<string> GenerateQuiz(string language, string level, string explanationContent)
        {
            string prompt = $@"بناءً على شرح لغة {language}، أنشئ 3 أسئلة اختبار بصيغة JSON فقط. استخدم هذا التنسيق بالضبط:

{{
    ""questions"": [
        {{
            ""question"": ""نص السؤال الأول"",
            ""options"": [""خيار 1"", ""خيار 2"", ""خيار 3"", ""خيار 4""],
            ""correct"": 0,
            ""explanation"": ""شرح الإجابة الصحيحة""
        }}
    ]
}}

ملاحظات:
1. correct يبدأ من 0 إلى 3
2. أخرج JSON فقط بدون أي نص إضافي
3. الأسئلة يجب أن تكون عن {language}

الشرح المرجعي: {(explanationContent?.Length > 500 ? explanationContent.Substring(0, 500) : explanationContent ?? "")}

الـ JSON:";

            return await GenerateResponse(prompt);
        }
    }

    public class OllamaResponse
    {
        public string response { get; set; } = "";
        public bool done { get; set; }
    }
}