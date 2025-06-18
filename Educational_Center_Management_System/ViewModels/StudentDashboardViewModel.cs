using Educational_Center_Management_System.DataAccessLayer;
using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services;
using System.Collections.ObjectModel;

namespace Educational_Center_Management_System.ViewModels
{
    class StudentDashboardViewModel
    {
        StudentService _studentService;
        public Student Student { get; set; }
        public ObservableCollection<ScoreForDisplay> Scores { get; set; }
        public ObservableCollection<Class> Classes { get; set; }
        public StudentDashboardViewModel(Student student)
        {
            Student = student;
            _studentService = new StudentService();
            Scores = new ObservableCollection<ScoreForDisplay>();
            Classes = new ObservableCollection<Class>();
            getListOfScores();
            getListOfClasses();
        }
        private async Task getListOfScores()
        {
            List<ScoreForDisplay> listOfScores = await _studentService.GetScore(Student.Id);
            foreach(ScoreForDisplay score in listOfScores)
                Scores.Add(score);
        }
        private async Task getListOfClasses()
        {
            List<Class> listOfClasses = await _studentService.GetClass(Student.Id);
            foreach (Class myClass in listOfClasses)
                Classes.Add(myClass);
        }
    }
}
