using Microsoft.Owin;
using Microsoft.Owin.Security;
using StudentManagement.Models;
using StudentManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web;
using StudentManagement.ViewModel;

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
        [AllowAnonymous]
        public HttpResponseMessage Login(LoginVM login)
        {
            
            int isAuthenticate = repo.Login(login.username, login.password);
            if (isAuthenticate > 0)
            {
                IOwinContext context = HttpContext.Current.GetOwinContext(); 
                IAuthenticationManager manager = context.Authentication;
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Name, login.username));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                ClaimsIdentity identities = new ClaimsIdentity(claims, "ApplicationCookie");
                manager.SignIn(identities: identities);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content =new StringContent("Login Successfully");
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.Content = new StringContent("Invalid username or password");
                return response;
            } 
        }

        [HttpPost]        
        [Route("signup")]
        [AllowAnonymous]
        public HttpResponseMessage Register(Student student)
        {           
            int isAuthenticate = repo.Registration(student);
            if (isAuthenticate > 0)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content =new StringContent("Register Successfully");
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent( "Please post valid data");
                return response;
            }
        }
    }
}
