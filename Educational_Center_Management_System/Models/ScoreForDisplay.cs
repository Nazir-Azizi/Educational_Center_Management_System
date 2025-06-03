
namespace Educational_Center_Management_System.Models
{
    public class ScoreForDisplay
    {
        public int ClassId { get; init; }
        public string ClassName { get; init; }
        public decimal Number { get; init; }
        public string TeacherName { get; init; }
        public DateOnly ClassDate { get; init; }
    }
}
