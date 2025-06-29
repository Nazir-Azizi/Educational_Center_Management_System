using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Educational_Center_Management_System.Models
{
    public record class Class
    {
        public int Id { get; set; }
        public int State { get; set; }
        public int Teacher { get; set; }
        public string Semester { get; set; }
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public DateOnly Date { get; set; }
        public ObservableCollection<ScoreHelper> ScoreHelpers { get; set; }
    }
}
