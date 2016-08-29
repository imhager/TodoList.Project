using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Entity;

namespace TodoList.Services
{
    public interface IUserService
    {

        IEnumerable<TodoUser> GetAll();

        Task<TodoUser> GetUser(int userid);

        void AddUser(TodoUser model);

        bool Update(TodoUser model);

        bool SaveChange();
    }
}
