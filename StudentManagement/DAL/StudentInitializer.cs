using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagement.DAL
{
    public class StudentInitializer: DropCreateDatabaseIfModelChanges<StudentDbContext>
    {
        protected override void Seed(StudentDbContext context)
        {
            var students = new List<Student>
            {
            new Student{Name="Tamim Iqbal",Email="tamim@yahoo.com",Username="tamim",Password="tamim123",Gender="Male",PhoneNo="123456",EnrollmentDate=DateTime.Parse("2002-03-01")},
            new Student{Name="Sakib Al Hasan",Email="sakibbd13@yahoo.com",Username="sakib",Password="sakib123",Gender="Male",PhoneNo="123342",EnrollmentDate=DateTime.Parse("2012-11-01")},
            new Student{Name="Afia Wasima",Email="afia@yahoo.com",Username="afia",Password="afia111",Gender="Female",PhoneNo="01478554685",EnrollmentDate=DateTime.Parse("2016-12-01")},
            new Student{Name="Abdul Zabbar",Email="abzab@yahoo.com",Username="zabbar",Password="admin123",Gender="Male",PhoneNo="325543",EnrollmentDate=DateTime.Parse("2002-03-01")},
            new Student{Name="Mostapha Sarwar",Email="sarwar@gmail.com",Username="msarwar",Password="sarwar222",Gender="Male",PhoneNo="01251448745",EnrollmentDate=DateTime.Parse("2012-03-11")},
            new Student{Name="Elina DCruz",Email="elina@gmail.com",Username="elinad",Password="eli123",Gender="Female",PhoneNo="258741",EnrollmentDate=DateTime.Parse("2011-05-01")},
            new Student{Name="Shah Rukh khan",Email="khan45@gmail.com",Username="shahrukh",Password="shahrukh123",Gender="Male",PhoneNo="432543",EnrollmentDate=DateTime.Parse("2002-03-01")},
            new Student{Name="Elsa Queen",Email="elsa@gmail.com",Username="elsa",Password="rlsa333",Gender="Male",PhoneNo="123456",EnrollmentDate=DateTime.Parse("2005-09-08")},
            new Student{Name="Shahid AB",Email="shahid@gmail.com",Username="shahid",Password="admin123",Gender="Male",PhoneNo="24422400",EnrollmentDate=DateTime.Parse("2008-04-01")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            //var courses = new List<Course>
            //{
            //new Course{CourseID=1050,Title="Chemistry",Credits=3,},
            //new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
            //new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
            //new Course{CourseID=1045,Title="Calculus",Credits=4,},
            //new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
            //new Course{CourseID=2021,Title="Composition",Credits=3,},
            //new Course{CourseID=2042,Title="Literature",Credits=4,}
            //};
            //courses.ForEach(s => context.Courses.Add(s));
            //context.SaveChanges();
            //var enrollments = new List<Enrollment>
            //{
            //new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            //new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            //new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            //new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            //new Enrollment{StudentID=3,CourseID=1050},
            //new Enrollment{StudentID=4,CourseID=1050,},
            //new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            //new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            //new Enrollment{StudentID=6,CourseID=1045},
            //new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            //};
            //enrollments.ForEach(s => context.Enrollments.Add(s));
            //context.SaveChanges();
        }
    }
}