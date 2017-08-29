using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.ViewModel
{
    public class CourseVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Double? Duration { get; set; }
        public string Description { get; set; }
    }
}