using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoList.DbMapping;
using TodoList.Entity;

namespace TodoList.Services
{
    public interface ITodoItemService : IBaseRepository<TodoItem, int>
    {

    }
    public class TodoItemService : ITodoItemService
    {
        private readonly ILogger<UserService> _logger;
        private readonly SqlitesWithIdentityDbContext _dbContext;

        public TodoItemService(SqlitesWithIdentityDbContext dbContext, ILogger<UserService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IEnumerable<TodoItem> GetList(int userId)
        {
            return _dbContext.TodoItems.Where(p => p.UserId == userId).OrderByDescending(p=>p.Id).ToList();
        }

        public TodoItem GetSingle(int id)
        {
            return _dbContext.TodoItems.FirstOrDefault(p => p.Id == id);
        }

        public bool Add(TodoItem model)
        {
            _dbContext.TodoItems.Add(model);

            return SaveChange();
        }

        public bool Update(TodoItem model)
        {
            _dbContext.TodoItems.Update(model);

            return SaveChange();
        }

        public bool Delete(int id)
        {
            var model = GetSingle(id);
            _dbContext.TodoItems.Remove(model);

            return SaveChange();
        }

        public bool SaveChange()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
