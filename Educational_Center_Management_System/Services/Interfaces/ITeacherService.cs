using Educational_Center_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational_Center_Management_System.Services.Interfaces
{
    internal interface ITeacherService
    {
        public List<Class> GetClasses(int teacherId);
        public bool SetScore(Score score);
        public bool UpdateScore(Score score);
    }
}
