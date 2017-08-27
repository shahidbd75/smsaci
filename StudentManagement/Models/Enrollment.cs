using StudentManagement.Common;
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
        public string IsCompleted { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}