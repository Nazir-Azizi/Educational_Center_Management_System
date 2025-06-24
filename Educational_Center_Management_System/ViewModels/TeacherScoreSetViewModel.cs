using Educational_Center_Management_System.Helpers;
using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services;
using Educational_Center_Management_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Educational_Center_Management_System.ViewModels
{
    class TeacherScoreSetViewModel
    {
        private ITeacherService _teacherService;
        private Teacher _teacher;
        private List<ScoreHelper> listOfAllScoreHelpers;
        public ObservableCollection<Class> Classes { get; set; }
        public ICommand SaveCommand { get; }
        public TeacherScoreSetViewModel(Teacher teacher)
        {
            _teacher = teacher;
            _teacherService = new TeacherService();
            Classes = new ObservableCollection<Class>();
            listOfAllScoreHelpers = new List<ScoreHelper>();
            _ = getTeacherClassesAndStudents();
            SaveCommand = new RelayCommand(ExecuteSaveCommand);
        }
        
        private async Task getTeacherClassesAndStudents()
        {
            List<Class> listOfClasses = await _teacherService.GetClasses(_teacher.Id);
            foreach(Class myClass in listOfClasses)
            {
                if (myClass.State == 0)
                {
                    myClass.ScoreHelpers = new ObservableCollection<ScoreHelper>();
                    Classes.Add(myClass);
                }
            }

            foreach (Class myClass in Classes)
            {
                List<Student> students = await _teacherService.GetStudentsOfClass(myClass.Id);
                foreach (Student student in students)
                {
                    Score? score = await _teacherService.GetStudentScore(student.Id, myClass.Id);
                    ScoreHelper scoreHelper = new ScoreHelper
                    {
                        ScoreId = score == null? -1 : score.Id,
                        Id = student.Id,
                        ClassId = myClass.Id,
                        Name = student.Name,
                        LastName = student.LastName,
                        Score = score == null ? -1 : score.Number
                    };
                    listOfAllScoreHelpers.Add(scoreHelper);
                    myClass.ScoreHelpers.Add(scoreHelper);
                }
            }
        }  
        private async void ExecuteSaveCommand(object? parameter)
        {
            int count = 0;
            foreach(ScoreHelper scoreHelper in listOfAllScoreHelpers)
            {
                Score score = new Score
                {
                    Id = scoreHelper.ScoreId,
                    StudentId = scoreHelper.Id,
                    ClassId = scoreHelper.ClassId,
                    Number = scoreHelper.Score
                };
                if (score.Number < 0 || score.Number > 100)
                {
                    MessageBox.Show($"{scoreHelper.Name}\'s number is out of range. Not saved");
                    scoreHelper.Score = -1;
                    continue;
                }
                if (score.Id == -1)
                    _ = await _teacherService.SetScore(score);
                else
                    _ = await _teacherService.UpdateScore(score);
                count++;
            }
            MessageBox.Show($"{count} score(s) saved/updated successfully");
        }

    }
}
