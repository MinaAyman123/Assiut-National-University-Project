using System.ComponentModel.DataAnnotations;

namespace AI_Programming_Assistant.Models
{
    public class Language
    {
        public string Name { get; set; } = "";
        public List<Level> Levels { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class Level
    {
        public int Id { get; set; }
        public int LevelNumber { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Content { get; set; } = "";
        public bool IsCompleted { get; set; }
        public bool IsUnlocked { get; set; }
        public double QuizPassScore { get; set; } = 0.7;
    }

    public class Quiz
    {
        public int LevelId { get; set; }
        public List<QuizQuestion> Questions { get; set; } = new();
        public double PassingScore { get; set; } = 0.7;
    }

    public class QuizQuestion
    {
        public string Question { get; set; } = "";
        public List<string> Options { get; set; } = new();
        public int CorrectAnswer { get; set; }
        public string Explanation { get; set; } = "";
    }

    public class UserProgress
    {
        public string Language { get; set; } = "";
        public int CurrentLevel { get; set; }
        public List<int> CompletedLevels { get; set; } = new();
        public Dictionary<int, double> QuizScores { get; set; } = new();
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }

    public class LearningSystemViewModel
    {
        public string SelectedLanguage { get; set; } = "";
        public Language? CurrentLanguage { get; set; }
        public Level? CurrentLevel { get; set; }
        public UserProgress? Progress { get; set; }
        public Quiz? CurrentQuiz { get; set; }
        public bool ShowQuiz { get; set; }
        public string? QuizResult { get; set; }
        public bool QuizPassed { get; set; }
    }
}