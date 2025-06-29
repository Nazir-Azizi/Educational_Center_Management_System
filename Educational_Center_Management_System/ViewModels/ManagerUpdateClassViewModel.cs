using Educational_Center_Management_System.Helpers;
using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services;
using Educational_Center_Management_System.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
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
    public class ManagerUpdateClassViewModel : BaseViewModel
    {
        private IManagerService _managerService;
        public Class MyClass { get; set; } = new Class();
        private int _state;

        public int State
        {
            get { return _state; }
            set
            {
                _state = value;
                onPropertyChanged();
            }
        }
        private Teacher? teacher;

        public Teacher? Teacher
        {
            get { return teacher; }
            set
            {
                teacher = value;
                onPropertyChanged();
            }
        }
        public DateTime? ClassDate { get; set; }
        public ObservableCollection<int> Hours { get; } = new ObservableCollection<int>(Enumerable.Range(0, 24));
        public ObservableCollection<int> Minutes { get; } = new ObservableCollection<int>(Enumerable.Range(0, 60));

        public int SelectedHour { get; set; }
        public int SelectedMinute { get; set; }
        public ObservableCollection<int> States { get; set; } = new ObservableCollection<int> { 0, 1 };
        public ObservableCollection<Teacher?> Teachers { get; set; } = new ObservableCollection<Teacher?>();
        public ICommand UpdateCommand { get; set; }
        public ManagerUpdateClassViewModel()
        {
            State = 0;
            _managerService = new ManagerService();
            _ = getTeachers();
            UpdateCommand = new RelayCommand(ExecuteUpdateCommand);
        }
        private async Task getTeachers()
        {
            List<Teacher?> list = await _managerService.GetAllTeachers();
            foreach (Teacher? teacher in list)
            {
                if (teacher != null)
                    Teachers.Add(teacher);
            }
        }
        private async void ExecuteUpdateCommand(object? parameter)
        {
            DateOnly? date = ClassDate.HasValue ? DateOnly.FromDateTime(ClassDate.Value) : null;
            if (Teacher == null
                || MyClass.Name.IsNullOrEmpty()
                || MyClass.Semester.IsNullOrEmpty()
                || date == null
                || (SelectedHour == 0 && SelectedMinute == 0))
            {
                MessageBox.Show("Set all properties");
            }
            else
            {
                TimeSpan selectedTime = new TimeSpan(SelectedHour, SelectedMinute, 0);
                MyClass.Teacher = Teacher.Id;
                MyClass.State = State;
                MyClass.Date = (DateOnly)date;
                MyClass.Time = selectedTime;
                bool res = await _managerService.UpdateClass(MyClass);
                MessageBox.Show(res ? "Class updated successfully" : $"No class with ID: {MyClass.Id}");
            }

        }
    }
}
