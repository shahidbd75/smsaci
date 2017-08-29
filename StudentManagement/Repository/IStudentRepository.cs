using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repository
{
    interface IStudentRepository
    {
        int Registration(Student student);
        int Login(string username, string password);
        IEnumerable<Student> GetAllStudent();
        Student GetStudent(int id);
        IEnumerable<CourseVM> StudentCourseList(int StudentId);
        IEnumerable<CourseVM> CompleteCourseList(int StudentId);
        IEnumerable<CourseVM> InCompleteCourseList(int StudentId);
        IEnumerable<ExamVM> ExamList(int StudentId);
    }
}
