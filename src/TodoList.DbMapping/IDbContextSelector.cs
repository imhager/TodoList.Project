using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.DbMapping
{
    /// <summary>
    /// TODO 后续，如何实现多数据库切换
    /// </summary>
    public interface IDbContextSelector
    {
        void ConfigureDbContext(IServiceCollection services, IConfigurationRoot configuration);
    }
}
