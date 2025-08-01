﻿using Educational_Center_Management_System.Helpers;
using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services;
using Educational_Center_Management_System.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Educational_Center_Management_System.ViewModels
{
    public class ManagerUpdateStudentViewModel
    {
        private byte[] imageBytes;
        private IManagerService _managerService;
        public Student Student { get; set; } = new Student();
        public DateTime? BirthDate { get; set; }
        public DateTime? JoinDate { get; set; }
        public ICommand AddPhotoCommand { get; set; }
        public ICommand SubmitCommand { get; set; }
        public ManagerUpdateStudentViewModel()
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
            if (Student.Id == 0
                || Student.Name.IsNullOrEmpty()
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
                bool res = await _managerService.UpdateStudent(Student);
                MessageBox.Show(res ? "Student Updated Successfuly" : "No student with such id");
            }
        }
    }
}
