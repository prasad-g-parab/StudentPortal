using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;

namespace StudentPortal.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {

            var u = HttpContext.User;
            if (u != null && u.FindFirstValue(ClaimTypes.Role) != null)
            {
                String role = u.FindFirstValue(ClaimTypes.Role);

                switch (role)
                {
                    case "Student":
                        return View("~/Views/Student/home.cshtml");

                    case "Admin":
                        return View("~/Views/Admin/home.cshtml");

                    case "Faculty":
                        return View("~/Views/Faculty/home.cshtml");

                    default:
                        ErrorViewModel er = new ErrorViewModel();
                        er.RequestId = "125";
                        return View("Error", er);
                }

            }

            


            return View("~/Views/auth/login.cshtml");
        }

        public IActionResult Test()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
