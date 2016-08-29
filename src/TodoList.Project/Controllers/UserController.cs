using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            IEnumerable<TodoUser> users = _userService.GetAll().ToList();

            return View(users);
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
            SelectListItem[] items =
            {
                new SelectListItem() {Text = "男♂", Value = "1"},
                new SelectListItem() {Text = "女♀", Value = "0"}
            };


            ViewBag.gender = items;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(TodoUser user)
        {
            if (ModelState.IsValid)
            {
                user.CreateTime = DateTime.Now;
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

            if (model == null) return RedirectToAction("404", "Page"); // 路由重写，对应的是Error/Notfound404

            SelectListItem[] items =
            {
                new SelectListItem() {Text = "男♂", Value = "1"},
                new SelectListItem() {Text = "女♀", Value = "0"}
            };


            ViewBag.gender = items;
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
                user.CreateTime = DateTime.Now;
                _userService.Update(user);
                //_userService.SaveChange();

                return RedirectToAction("Index");
            }


            return View();

        }
    }
}
