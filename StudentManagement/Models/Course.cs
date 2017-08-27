using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public Double Duration { get; set; }
        public string Description { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}