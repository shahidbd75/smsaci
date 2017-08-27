using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Double Duration { get; set; }
        public string Description { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}