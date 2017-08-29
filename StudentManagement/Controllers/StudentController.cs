using StudentManagement.Models;
using StudentManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentManagement.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        StudentRepository repo = new StudentRepository();
        [HttpGet]
        [Route("getallstudent")]
        public IHttpActionResult GetAllStudent()
        {
            return Ok(repo.GetAllStudent().ToList());
        }

        [HttpGet]
        [Route("getstudent")]
        public IHttpActionResult GetStudent(int id)
        {
            var student = repo.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet]
        [Route("studentexamlist")]
        public IHttpActionResult ExamList(int id)
        {
            var exam = repo.ExamList(id).ToList();
            if(exam ==null)
            {
                return NotFound();
            }
            return Ok(exam);
        }

        [HttpGet]
        [Route("incompletecoursebyid")]
        public IHttpActionResult InCompleteCourseList(int id)
        {
            try
            {
                var course = repo.InCompleteCourseList(id).ToList();
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch (Exception ex)
            {
                return InternalServerError();           }
        }
        [HttpGet]
        [Route("completecoursebyid")]
        public IHttpActionResult CompleteCourseList(int id)
        {
            try
            {
                var course = repo.CompleteCourseList(id).ToList();
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch (Exception ex)
            {

                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("studentcourselistbystudentid")]
        public IHttpActionResult StudentCourseList(int id)
        {
            var courseList = repo.StudentCourseList(id).ToList();
            if (courseList == null)
            {
                return NotFound();
            }
            return Ok(courseList);
        }

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(string username,string password)
        {
            int isAuthenticate = repo.Login(username, password);
            if (isAuthenticate > 0)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }else
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response.RequestMessage.CreateResponse(HttpStatusCode.Unauthorized,"invalid username or password");
                return response;
            } 
        }

        [HttpPost]
        [Route("signup")]
        public HttpResponseMessage Register(Student student)
        {
            int isAuthenticate = repo.Registration(student);
            if (isAuthenticate > 0)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response.RequestMessage.CreateResponse(HttpStatusCode.Unauthorized, "invalid username or password");
                return response;
            }
        }
    }
}
