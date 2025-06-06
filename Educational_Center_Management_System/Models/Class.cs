﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational_Center_Management_System.Models
{
    public record class Class
    {
        public int Id { get; init; }
        public int State { get; init; }
        public int Teacher { get; init; }
        public string Semester { get; init; }
        public string Name { get; init; }
        public TimeSpan Time { get; init; }
        public DateOnly Date { get; init; }
    }
}
