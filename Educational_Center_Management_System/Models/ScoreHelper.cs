using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational_Center_Management_System.Models
{
    public class ScoreHelper
    {
        public int ScoreId { get; set; }
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal Score { get; set; }
    }
}
