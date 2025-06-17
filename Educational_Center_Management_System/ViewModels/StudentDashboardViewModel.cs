using Educational_Center_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational_Center_Management_System.ViewModels
{
    class StudentDashboardViewModel
    {
        public Student Student { get; set; }

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
        }
    }
}
