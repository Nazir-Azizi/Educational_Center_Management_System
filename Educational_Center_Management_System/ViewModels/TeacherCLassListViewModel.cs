using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace Educational_Center_Management_System.ViewModels
{
    class TeacherCLassListViewModel
    {
        TeacherService _teacherService;
        private Teacher _teacher;
        public ObservableCollection<Class> Classes { get; set; }
        public TeacherCLassListViewModel(Teacher teacher)
        {
            _teacher = teacher;
            _teacherService = new TeacherService();
            Classes = new ObservableCollection<Class>();
            getListOfClasses();
        }
        private async Task getListOfClasses()
        {
            List<Class> listOfClasses = await _teacherService.GetClasses(_teacher.Id);
            foreach (Class myClass in listOfClasses)
                Classes.Add(myClass);
        }
    }
}
