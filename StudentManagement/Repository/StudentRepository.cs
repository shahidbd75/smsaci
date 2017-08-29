using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentManagement.Models;
using StudentManagement.ViewModel;

namespace StudentManagement.Repository
{
    public class StudentRepository : IStudentRepository
    {
        StudentDbContext db;
        public StudentRepository() {
             db= new StudentDbContext();
        }
        public IEnumerable<CourseVM> CompleteCourseList(int StudentId)
        {
            return db.Enrollments.Include("Course").Where(e => e.IsCompleted == true && e.StudentID == StudentId).Select(s => new CourseVM
            {
                Id = s.CourseID,
                Name = s.Course.Name,
                Duration =s.Course.Duration,
                Description =s.Course.Description
            });
        }

        public IEnumerable<ExamVM> ExamList(int StudentId)
        {
            var result = from ex in db.Exams
                         join en in db.Enrollments on ex.EnrollmentID equals en.EnrollmentID
                         join c in db.Courses on en.CourseID equals c.Id
                         where en.StudentID == StudentId
                         select new ExamVM()
                         {
                             CourseName = c.Name,
                             Exams = ex
                         };
            return result;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return db.Students.ToList();
        }

        public Student GetStudent(int id)
        {
            return db.Students.Find(id);
        }

        public IEnumerable<CourseVM> InCompleteCourseList(int StudentId)
        {
            //var result = from e in db.Enrollments
            //             join c in db.Courses on e.EnrollmentID equals c.Id
            //             where e.IsCompleted == false && e.StudentID == StudentId
            //             select new 
            //             {
            //                 Id=c.Id,
            //                 Name= c.Name,
            //                 Description = c.Description,
            //                 Duration =c.Duration
            //             };
            //var r = result.Select(x=>new CourseVM() {Id =x.Id,Name=x.Name }).ToList();
            return db.Enrollments.Include("Course").Where(e => e.IsCompleted == false && e.StudentID == StudentId).Select(s => new CourseVM
            {
                Id = s.CourseID,
                Name = s.Course.Name,
                Description =s.Course.Description,
                Duration =s.Course.Duration
            });
        }

        public int Login(string username, string password)
        {
            try
            {
                var stud = db.Students.FirstOrDefault(s => s.Username == username && s.Password == password);
                if (stud != null)
                {
                    return 1;
                }
            }
            catch
            {

            }
            return 0;
        }

        public int Registration(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return 1;
        }

        public IEnumerable<CourseVM> StudentCourseList(int StudentId)
        {
            var result = from e in db.Enrollments
                         join c in db.Courses on e.CourseID equals c.Id
                         where e.StudentID == StudentId
                         select new CourseVM
                         {
                             Id = c.Id,
                             Name = c.Name,
                             Description =c.Description,
                             Duration =c.Duration
                         };
            return result;
        }
    }
}