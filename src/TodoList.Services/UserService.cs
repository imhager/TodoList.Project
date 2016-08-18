using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using TodoList.Entity;
using TodoList.DbMapping;

namespace TodoList.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly SqlLitesDbContext _dbContext;

        public UserService(ILogger<UserService> logger, SqlLitesDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Task<TodoUser> GetUser(int userid)
        {
            return _dbContext.TodoUsers.FirstOrDefaultAsync(p => p.Id == userid);
        }

        public void AddUser(TodoUser model)
        {
            _dbContext.TodoUsers.Add(model);
            //_dbContext.SaveChanges();
            //SaveChange();
        }

        public bool Update(TodoUser model)
        {
            var updateModel = new TodoUser
            {
                Id = model.Id,
                Brithday = model.Brithday,
                UserName = model.UserName,
                Sex = model.Sex,
                NickName = model.NickName
            };
            _dbContext.TodoUsers.Update(updateModel);

            //return _dbContext.SaveChanges() > 0;
            return SaveChange();
        }

        public bool SaveChange()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
