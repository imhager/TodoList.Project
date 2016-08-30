using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Entity;

namespace TodoList.Services
{

    public interface ICountryService
    {
        IEnumerable<CountryModel> GetAll();
    }

    public class CountryService : ICountryService
    {
        private static IEnumerable<CountryModel> CountryList = new List<CountryModel>()
        {
            new CountryModel() { Id=1,enName="China",CnName="中国",Code="China"},
            new CountryModel() { Id=2,enName="Japan",CnName="日本",Code="Japan"},
            new CountryModel() { Id=3,enName="America",CnName="美国",Code="America"},
        };
        public IEnumerable<CountryModel> GetAll()
        {
            return CountryList;
        }
    }
}
