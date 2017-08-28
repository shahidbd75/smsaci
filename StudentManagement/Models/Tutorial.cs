using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Tutorial
    {
        [Key]
        public int TutorialId { get; set; }
        public string TutorialName { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }

        public Student Student { get; set; }
    }
}