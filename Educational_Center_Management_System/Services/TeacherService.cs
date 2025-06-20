﻿using Educational_Center_Management_System.DataAccessLayer.Repositories.TeacherRepositories;
using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services.Interfaces;


namespace Educational_Center_Management_System.Services
{
    internal class TeacherService : ITeacherService
    {
        private readonly TeacherServiceRepository _teacherServiceRepository;
        public TeacherService()
        {
            _teacherServiceRepository = new TeacherServiceRepository();
        }
        public Task<List<Class>> GetClasses(int teacherId)
        {
            return _teacherServiceRepository.GetClasses(teacherId);
        }

        public Task<bool> SetScore(Score score)
        {
            return _teacherServiceRepository.SetScore(score);
        }

        public Task<bool> UpdateScore(Score score)
        {
            return _teacherServiceRepository.UpdateScore(score);
        }
    }
}
