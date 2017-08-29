using StudentManagement.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Exam
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Attend Date")]
        public DateTime AttandDate { get; set; }
        [ForeignKey("Enrollment")]
        public int EnrollmentID { get; set; }
        public Grade? Grade { get; set; }

        public Enrollment Enrollment { get; set; }
    }
}