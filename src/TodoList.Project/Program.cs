using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace TodoList.Project
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //方式一，引入文件 自定义server.urls
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/hostsettings.Development.json", optional: true, reloadOnChange: true).Build();


            // 方式二，需要引入Microsoft.Extensions.Configuration.CommandLine
            // 然后，执行dotnet run --server.urls "http://localhost:5001;http://localhost:5002;http://*:5003"
            //var config = new ConfigurationBuilder()
            //   .AddCommandLine(args)
            //   .Build();

            var host = new WebHostBuilder()
                .UseConfiguration(config) // 使用自定义server.urls，可以开启多个端口
                //.UseUrls("http://localhost:9527;http://localhost:9528;http://*:9529")
                .UseKestrel() // 跨平台服务
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration() // IIS扩展运行，需要在IIS上安装一个扩展
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
