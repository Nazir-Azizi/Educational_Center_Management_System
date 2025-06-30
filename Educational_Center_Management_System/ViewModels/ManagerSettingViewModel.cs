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
    public class ManagerSettingViewModel
    {
        private IManagerService _managerService;
        private byte[] imageBytes;
        public Manager Manager { get; set; } = new Manager();
        public ICommand AddPhotoCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ManagerSettingViewModel()
        {
            _managerService = new ManagerService();
            AddPhotoCommand = new RelayCommand(ExecuteAddPhotoCommand);
            UpdateCommand = new RelayCommand(ExecuteUpdateCommand);
        }
        private void ExecuteAddPhotoCommand (object? parameter)
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
        private async void ExecuteUpdateCommand(object? parameter)
        {
            if (Manager.Name.IsNullOrEmpty()
                || Manager.LastName.IsNullOrEmpty()
                || Manager.Password.IsNullOrEmpty()
                || imageBytes == null)
            {
                MessageBox.Show("Set all properties");
            }
            else
            {
                Manager.Photo = imageBytes;
                bool res = await _managerService.UpdataManager(Manager);
                MessageBox.Show(res ? "Manager updated successfully" : "There was an error");
            }
        }
    }
}
