using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestMVC.Models;
using TestMVC.Service;

namespace TestMVC.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(UserDetails u)
        {
            EmployeeService bal = new EmployeeService();
            if (ModelState.IsValid)
            {
                if (bal.IsValidUser(u))
                {
                    FormsAuthentication.SetAuthCookie(u.UserName, false);
                    return RedirectToAction("getEmployeeListByEntity", "Employee");
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }


        [HttpPost]
        //Day 5
        public ActionResult DoLogin1(UserDetails u)
        {
            EmployeeService bal = new EmployeeService();
            if (ModelState.IsValid)
            {
                //New Code start
                UserStatus status = bal.GetUserValidity(u);
                bool isAdmin = false;

                if (status == UserStatus.AuthenticatedAdmin)
                {
                    isAdmin = true;
                }
                else if (status == UserStatus.AuthentucatedUser)
                {
                    isAdmin = false;
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login");
                }

                FormsAuthentication.SetAuthCookie(u.UserName, false);
                Session["isAdmin"] = isAdmin;
                return RedirectToAction("getEmployeeListByEntity", "Employee");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
	}
}