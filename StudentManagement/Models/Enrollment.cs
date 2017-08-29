using StudentManagement.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        [Display(Name ="Is Completed")]
        public bool IsCompleted { get; set; } = false;
        [DataType(DataType.Date)]
        [Display(Name ="Enrollment Date")]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}