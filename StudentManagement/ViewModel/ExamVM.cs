using StudentManagement.Common;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.ViewModel
{
    public class ExamVM
    {
        public ExamVM(Exam exam)
        {
            Exams.Id = exam.Id;
            Exams.AttandDate = exam.AttandDate;
            Exams.Grade = exam.Grade;
        }
        public ExamVM() { }
        public Exam Exams { get; set; }
        public string CourseName { get; set; }
    }
}