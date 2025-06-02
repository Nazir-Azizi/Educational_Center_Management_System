using Educational_Center_Management_System.DataAccessLayer.Repositories.TeacherRepositories;
using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational_Center_Management_System.Services
{
    internal class TeacherService : ITeacherService
    {
        private readonly TeacherServiceRepository _teacherServiceRepository;
        public TeacherService()
        {
            _teacherServiceRepository = new TeacherServiceRepository();
        }
        public List<Class> GetClasses(int teacherId)
        {
            return _teacherServiceRepository.GetClasses(teacherId);
        }

        public bool SetScore(Score score)
        {
            return _teacherServiceRepository.SetScore(score);
        }

        public bool UpdateScore(Score score)
        {
            return _teacherServiceRepository.UpdateScore(score);
        }
    }
}
