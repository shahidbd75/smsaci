using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.ViewModel
{
    public class LoginVM
    {
        public string username { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}