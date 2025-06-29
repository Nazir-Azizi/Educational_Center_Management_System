using Educational_Center_Management_System.Helpers;
using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services;
using Educational_Center_Management_System.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Input;

namespace Educational_Center_Management_System.ViewModels
{
    public class ManagerUpdateTeacherViewModel
    {
        private IManagerService _managerService;
        public Teacher Teacher { get; set; } = new Teacher();
        public DateTime? BirthDate { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public ICommand AddPhotoCommand { get; set; }
        public ICommand SubmitCommand { get; set; }
        public ManagerUpdateTeacherViewModel()
        {
            AddPhotoCommand = new RelayCommand(ExecuteAddPhotoCommand);
            SubmitCommand = new RelayCommand(ExecuteSubmitCommand);
            _managerService = new ManagerService();
        }
        private void ExecuteAddPhotoCommand(object? parameter)
        {
            MessageBox.Show("Not implmented yet. Coming Soon!");
        }
        private async void ExecuteSubmitCommand(object? parameter)
        {
            DateOnly? birthDate = BirthDate.HasValue ? DateOnly.FromDateTime(BirthDate.Value) : null;
            DateOnly? joinDate = JoinDate.HasValue ? DateOnly.FromDateTime(JoinDate.Value) : null;
            DateOnly? leaveDate = LeaveDate.HasValue ? DateOnly.FromDateTime(LeaveDate.Value) : null;
            if (Teacher.Id == 0
                || Teacher.Name.IsNullOrEmpty()
                || Teacher.LastName.IsNullOrEmpty()
                || Teacher.Fathername.IsNullOrEmpty()
                || Teacher.PhoneNumber.IsNullOrEmpty()
                || Teacher.Password.IsNullOrEmpty()
                || birthDate == null
                || joinDate == null
                )
            {
                MessageBox.Show("Not all properties are set!");
            }
            else
            {
                Teacher.BirthDate = (DateOnly)birthDate;
                Teacher.JoinDate = (DateOnly)joinDate;
                Teacher.LeaveDate = leaveDate;
                bool res = await _managerService.UpdateTeacher(Teacher);
                MessageBox.Show(res ? "Teacher Updated Successfuly" : "No Teacher with such id");
            }
        }
    }
}
