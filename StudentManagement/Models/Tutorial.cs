using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Tutorial
    {
        public int TutorialId { get; set; }
        public int StudentId { get; set; }
        public string TutorialName { get; set; }
        public byte[] Content { get; set; }
    }
}