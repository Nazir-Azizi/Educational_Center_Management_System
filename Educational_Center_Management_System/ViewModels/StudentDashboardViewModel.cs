using Educational_Center_Management_System.Models;
using System.Collections.ObjectModel;

namespace Educational_Center_Management_System.ViewModels
{
    class StudentDashboardViewModel
    {
        public Student Student { get; set; }
        public ObservableCollection<ScoreForDisplay> Scores { get; set; }
        public ObservableCollection<Class> Classes { get; set; }
        public StudentDashboardViewModel(/*Student student*/)
        {
            Student = new Student
            {
                Id = 1,
                Name = "Nazir",
                LastName = "Azizi",
                Fathername = "Mohammad Aziz",
                BirthDate = new DateOnly(2005, 12, 19),
                Photo = null, // Assuming photo is not required for this test
                PhoneNumber = "0783360601",
                JoinDate = new DateOnly(2030, 9, 1),
                State = 1,
                Password = "faty"

            };
            Scores = new ObservableCollection<ScoreForDisplay>
            {
                new ScoreForDisplay
                {
                    ClassId = 101,
                    ClassName = "Prep",
                    Number = 91.9M,
                    TeacherName = "Azizi",
                    ClassDate = new DateOnly(2024, 1, 6)
                },
                new ScoreForDisplay
                {
                    ClassId = 1,
                    ClassName = "Advance A",
                    Number = 56.7M,
                    TeacherName = "Azizi",
                    ClassDate = new DateOnly(2024, 5, 6)
                },
                new ScoreForDisplay
                {
                    ClassId = 101,
                    ClassName = "Prep",
                    Number = 91.9M,
                    TeacherName = "Azizi",
                    ClassDate = new DateOnly(2024, 1, 6)
                },
                new ScoreForDisplay
                {
                    ClassId = 1,
                    ClassName = "Advance A",
                    Number = 56.7M,
                    TeacherName = "Azizi",
                    ClassDate = new DateOnly(2024, 5, 6)
                },
                new ScoreForDisplay
                {
                    ClassId = 101,
                    ClassName = "Prep",
                    Number = 91.9M,
                    TeacherName = "Azizi",
                    ClassDate = new DateOnly(2024, 1, 6)
                },
                new ScoreForDisplay
                {
                    ClassId = 1,
                    ClassName = "Advance A",
                    Number = 56.7M,
                    TeacherName = "Azizi",
                    ClassDate = new DateOnly(2024, 5, 6)
                },
                new ScoreForDisplay
                {
                    ClassId = 101,
                    ClassName = "Prep",
                    Number = 91.9M,
                    TeacherName = "Azizi",
                    ClassDate = new DateOnly(2024, 1, 6)
                },
                new ScoreForDisplay
                {
                    ClassId = 1,
                    ClassName = "Advance A",
                    Number = 56.7M,
                    TeacherName = "Azizi",
                    ClassDate = new DateOnly(2024, 5, 6)
                },
                new ScoreForDisplay
                {
                    ClassId = 101,
                    ClassName = "Prep",
                    Number = 91.9M,
                    TeacherName = "Azizi",
                    ClassDate = new DateOnly(2024, 1, 6)
                },
                new ScoreForDisplay
                {
                    ClassId = 1,
                    ClassName = "Advance A",
                    Number = 56.7M,
                    TeacherName = "Azizi",
                    ClassDate = new DateOnly(2024, 5, 6)
                }
            };
            Classes = new ObservableCollection<Class>
            {
                new Class
                {
                    Id = 1023,
                    State = 1,
                    Teacher = 1,
                    Semester = "AP",
                    Name = "Prep",
                    Time = new TimeSpan(6, 30,0),
                    Date = new DateOnly(2024, 5, 1)
                },
                new Class
                {
                    Id = 5643,
                    State = 1,
                    Teacher = 2,
                    Semester = "AZ",
                    Name = "Level Six",
                    Time = new TimeSpan(14, 0,0),
                    Date = new DateOnly(2024, 10, 1)
                }
            };
        }
    }
}
