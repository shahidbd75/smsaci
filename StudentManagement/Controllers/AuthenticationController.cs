using Microsoft.Owin;
using Microsoft.Owin.Security;
using StudentManagement.Repository;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        StudentRepository repo = new StudentRepository();
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginVM());
        }
        [HttpPost]
        public ActionResult Login(LoginVM login, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                int isAuthenticate = repo.Login(login.username, login.password);
                if (isAuthenticate > 0)
                {
                    IOwinContext context = Request.GetOwinContext();
                    IAuthenticationManager manager = context.Authentication;
                    List<Claim> claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, login.username));
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                    ClaimsIdentity identities = new ClaimsIdentity(claims, "ApplicationCookie");
                    manager.SignIn(identities: identities);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
                //ReturnUrl == "" ? RedirectToAction("Index", "Home") : RedirectToRoute(ReturnUrl);
            }
            return View(login);
        }
        public ActionResult Logout()
        {
            IOwinContext context = Request.GetOwinContext();
            IAuthenticationManager manager = context.Authentication;
            manager.SignOut("ApplicationCookie");
            return Redirect("/");
        }
    }
}
