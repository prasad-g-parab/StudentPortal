using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentPortal.Controllers
{

    [Route("Faculty")]
    public class FacultyController : Controller
    {
        // GET: /<controller>/
        [Authorize(Roles = "Faculty")]
        public IActionResult Index()
        {
            return View("Home");
        }
    }
}
