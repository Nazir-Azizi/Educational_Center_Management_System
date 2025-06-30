using Educational_Center_Management_System.Enums;
using Educational_Center_Management_System.Helpers;
using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services;
using Educational_Center_Management_System.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Educational_Center_Management_System.ViewModels
{
    public class ManagerAddViewModel : BaseViewModel
    {
        private IManagerService _managerService;
        public Student Student { get; set; } = new Student();
        public DateTime? BirthDate { get; set; }
        public DateTime? JoinDate { get; set; }
        public ICommand AddPhotoCommand { get; set; }
        public ICommand SubmitCommand { get; set; }
        private UserType _selectedUserType = UserType.Student;
        private byte[] imageBytes;
        public UserType SelectedUserType
        {
            get { return _selectedUserType; }
            set
            {
                _selectedUserType = value;
                onPropertyChanged();
            }
        }
        public ManagerAddViewModel()
        {
            AddPhotoCommand = new RelayCommand(ExecuteAddPhotoCommand);
            SubmitCommand = new RelayCommand(ExecuteSubmitCommand);
            _managerService = new ManagerService();
        }
        private void ExecuteAddPhotoCommand(object? parameter)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Select a Photo",
                Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                imageBytes = File.ReadAllBytes(filePath);
            }
        }
        private async void ExecuteSubmitCommand(object? parameter)
        {
            DateOnly? birthDate = BirthDate.HasValue ? DateOnly.FromDateTime(BirthDate.Value) : null;
            DateOnly? joinDate = JoinDate.HasValue ? DateOnly.FromDateTime(JoinDate.Value) : null;
            if (Student.Name.IsNullOrEmpty()
                || Student.LastName.IsNullOrEmpty()
                || Student.Fathername.IsNullOrEmpty()
                || Student.PhoneNumber.IsNullOrEmpty()
                || Student.Password.IsNullOrEmpty()
                || birthDate == null
                || joinDate == null
                || imageBytes == null
                )
            {
                MessageBox.Show("Not all properties are set!");
            }
            else
            {
                Student.BirthDate = (DateOnly)birthDate;
                Student.JoinDate = (DateOnly)joinDate;
                Student.Photo = imageBytes;
                if (SelectedUserType == UserType.Student)
                {
                    bool res = await _managerService.AddStudent(Student);
                    MessageBox.Show(res ? "Student added Successfuly" : "There was an error");
                }
                else
                {
                    Teacher teacher = new Teacher();
                    teacher.Name = Student.Name;
                    teacher.LastName = Student.LastName;
                    teacher.Fathername = Student.Fathername;
                    teacher.BirthDate = Student.BirthDate;
                    teacher.PhoneNumber = Student.PhoneNumber;
                    teacher.JoinDate = Student.JoinDate;
                    teacher.State = Student.State;
                    teacher.Password = Student.Password;
                    teacher.Photo = Student.Photo;
                    bool res = await _managerService.AddTeacher(teacher);
                    MessageBox.Show(res ? "Teacher added Successfuly" : "There was an error");
                }
            }
        }

    }
}
