using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoList.Entity;
using TodoList.Entity.Enums;
using TodoList.Framework;
using TodoList.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoList.Project.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        private readonly ILogger<TodoController> _logger;
        private readonly IJsonSerializable _jsonSerializable;

        public TodoController(ITodoItemService todoItemService, ILogger<TodoController> logger, IJsonSerializable jsonSerializable)
        {
            _todoItemService = todoItemService;
            _logger = logger;
            _jsonSerializable = jsonSerializable;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            int userId = 9527;
            var list = _todoItemService.GetList(userId);// TODO 更改为从登录用户cookie中获取userid
            if (list == null) list = new List<TodoItem>();

            var AAList = list.Where(p => p.Level == (int)ImportLevelEnum.AA).ToList();
            if (AAList == null) AAList = new List<TodoItem>();

            ViewBag.AAList = AAList;

            var ABList = list.Where(p => p.Level == (int)ImportLevelEnum.AB).ToList();
            ViewBag.ABList = ABList;

            var BCList = list.Where(p => p.Level == (int)ImportLevelEnum.BC).ToList();
            ViewBag.BCList = BCList;

            var CCList = list.Where(p => p.Level == (int)ImportLevelEnum.CC).ToList();
            ViewBag.CCList = CCList;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(TodoItem item)
        {
            if (ModelState.IsValid)
            {
                item.CreateTime = DateTime.Now;
                item.UpdateTime = DateTime.MinValue;
                //item.Status = (int)TodoStatusEnum.New;
                item.Type = 0;
                item.UserId = 9527;
                item.UserName = "华生";

                _todoItemService.Add(item);
                return RedirectToAction("Index");
            }

            return View("Add");
        }

        public IActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException(nameof(id));
            var model = _todoItemService.GetSingle(int.Parse(id));
            if (model == null) return RedirectToAction("404", "Page");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TodoItem item)
        {
            if (ModelState.IsValid)
            {
                var model = _todoItemService.GetSingle(item.Id);
                if (model != null)
                {
                    model.Title = item.Title;
                    model.Descript = item.Descript;
                    model.Status = item.Status;
                    model.Level = item.Level;
                    model.UpdateTime = DateTime.Now;

                    _todoItemService.Update(model);

                    return RedirectToAction("Index");
                }
            }

            return View("Edit");
        }

        [HttpGet]
        public IActionResult Done(string id, int status)
        {
            var model = _todoItemService.GetSingle(int.Parse(id));
            if (model != null)
            {
                model.UpdateTime = DateTime.Now;
                model.Status = status;

                _todoItemService.Update(model);
            }
            var result = new ResponseResult<string>()
            {
                Code = 0,
                Msg = "",
                Result = ""
            };
            return Json(result);
        }
    }
}
