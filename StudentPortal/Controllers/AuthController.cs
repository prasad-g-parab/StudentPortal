using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Models.DAL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentPortal.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {

        private readonly DBContext _context;
       

        public AuthController(DBContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login(User user)
        {
            User currentUser = _context.Users.SingleOrDefault(s => s.email == user.email && s.password == user.password);
        

            if (currentUser != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, currentUser.email),
                new Claim(ClaimTypes.Role, currentUser.role),
                new Claim(ClaimTypes.Name, currentUser.firstName),
                new Claim(ClaimTypes.Surname, currentUser.lastName)
            };

                var claimsIdentity = new ClaimsIdentity(
                   claims, CookieAuthenticationDefaults.AuthenticationScheme);
                


                 var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
                };

                await HttpContext.SignInAsync(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(claimsIdentity),
                   authProperties);

                switch (currentUser.role)
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

            } else
            {
                return View("login", user);
            }

        }

        [AllowAnonymous]
        [HttpGet]
        [Route("login")]
        public IActionResult Login(User user)
        {
            return View("login");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("accesDenied")]
        public IActionResult accesDenied()
        {
            return View("accesDenied");
        }
    }
}
