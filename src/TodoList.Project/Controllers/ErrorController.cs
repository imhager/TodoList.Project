using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoList.Project.Controllers
{
    [Route("Page")]
    public class ErrorController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Route("404")]
        public IActionResult NotFound404()
        {
            return View("404");
        }
    }
}
