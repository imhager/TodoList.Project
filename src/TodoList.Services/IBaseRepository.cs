using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Services
{
    public interface IBaseRepository<T, in TType> where T : class
    {
        IEnumerable<T> GetList(TType id);

        T GetSingle(TType id);

        bool Add(T model);

        bool Update(T model);

        bool Delete(TType id);

        bool SaveChange();
    }
}
