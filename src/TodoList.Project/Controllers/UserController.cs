using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TodoList.Services;
using TodoList.Entity;
using TodoList.DbMapping;
using TodoList.Framework;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoList.Project.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IJsonSerializable _jsonSerializable;
        public UserController(IUserService userService, ILogger<UserController> logger, IJsonSerializable jsonSerializable)
        {
            _userService = userService;
            _logger = logger;
            _jsonSerializable = jsonSerializable;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUser(int? id)
        {
            if (id == null) return new NotFoundResult();

            Task<TodoUser> model = _userService.GetUser(id.Value);

            var result = _jsonSerializable.ToJson(model.Result);

            _logger.LogInformation(result);

            return Json(new { model });
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(TodoUser user)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(user);
                bool result = _userService.SaveChange();
                _logger.LogInformation("addUser:{0}", _jsonSerializable.ToJson(user));
            }
            else
            {
                return RedirectToAction("AddUser");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) RedirectToAction("Index");

            TodoUser model = _userService.GetUser(id.Value).Result;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TodoUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _userService.Update(user);
                //_userService.SaveChange();

                return RedirectToAction("Index");
            }


            return View();

        }
    }
}
