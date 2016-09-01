### lession 1 认识asp.net core
**功能改进点：**
   * A unified story for building web UI and web APIs 一个统一的构建web UI和web api的平台
   * Integration of modern client-side frameworks and development workflows 比较流行的客户端框架和开发工作流的集成
   * A cloud-ready environment-based configuration system 真正的基于云环境配置文件的系统
   * Built-in dependency injection 内置依赖注入
   * New light-weight and modular HTTP request pipeline 新的轻量级和模块化的http请求管道
   * Ability to host on IIS or self-host in your own process 基于IIS或者self-host的能力
   * Built on .NET Core, which supports true side-by-side app versioning 构建支持真正的应用程序版本控制
   * Ships entirely as NuGet packages 基于nuget包管理
   * New tooling that simplifies modern web development 新的简化Web开发的工具
   * Build and run cross-platform ASP.NET apps on Windows, Mac and Linux 基于多平台构建，比如windows，mac，linux平台
   * Open source and community focused 开源和社区支持

### Startup
> Starpup 类是定义请求处理管理和配置所需要的服务（Services）的地方。Startup必须声明为public，而且包含两个方法：
```c#
public class Startup
{
    // 定义一些应用程序中需要用到的services，比如Mvc coreFramework,Entity frameworkcore，identity等
    // 此方法用于向DIContainer中注入需要的service服务
    public void ConfigureServices(IServiceCollection services)
    {
    }
    // 定义一些中间件（middleware）,可以扩展几个参数，比如env,loggerFactory等
    public void Configure(IApplicationBuilder app[, IHostingEnvironment env, ILoggerFactory loggerFactory])
    {
    }
}
```

### Services
> 可以理解为是一个个的组件，用于为应用程序提供消费。aspnet core中自带了IOC 容器，默认是支持构造函数注入方式。其实你也可以更换为自己熟悉的DI container，比如Autofac等。
> 

### Middleware
> 中间件。主要是用于处理管道请求。比如增加IP请求记录、权限判定、日志记录等等；可以灵活地控制是否继续向下传递请求，还是直接拦截返回。
> 一般是在Startup.Configure方法中，使用“UseXXX”的方式调用一个基于IApplicationBuilder的扩展方法。
> 比如：
```C#
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    // the others 
    app.UseStaticFiles();
    app.UseIdentity();
    app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
}
```
> 如果自定义自己的middleware，需要特别注意的就是两个点，一个是请求代理的传递requestDelegate；一个是定义个基于HttpContext上下文的Invoke方法；
> 然后一个基于```IApplicationBuilder```的静态扩展方法，用```UseMiddleware<T>()```注册进去即可。

### Servers
> asp.net core提供了除了基于IIS之外的跨平台服务功能，比如kestrel.如果是在IIS中运行，需要安装一个基于IIS的扩展模块“HttpPlatformHandler”（IIS7.5+）；
> 其实，asp.netcore本身并不处理请求，它只是转发请求。然后由处理的应用程序组合成一个httpcontext。
> 
> The HttpPlatformHandler is a new component that connects IIS with your ASP.NET Core application. You can get that from the following download links.

 * 64 bit HttpPlatformHandler http://go.microsoft.com/fwlink/?LinkID=690721
 * 32 bit HttpPlatformHandler http://go.microsoft.com/fwlink/?LinkId=690722

### Configuration
> Asp.Net Core使用的是一个新的配置模型来处理KV键值对。新的配置模型既不是基于```System.Configuration```也不是基于我们熟悉的```web.config```;
> 而是一组命令提供者（providers），内建的配置提供者，支持很多格式（比如json，xml，ini），并且支持环境变量参数；同样你可以定义你自己的配置提供者。

### Environments
> 环境，其实像我们常说的“开发环境Development”、“正式环境Production”.可以根据设置的环境变量值不同，而灵活地选择对应的配置。
> 在VS2015中，创建项目时，默认会配置一个有关于环境的变量“```ASPNETCORE_ENVIRONMENT```”，同时，默认被指定为了“Development”；你可以从项目属性中，找到“调试”Tab，里面就可以看到。
> 你可以以这种方式配置，也可以配置成系统级别的环境变量（比如windows下增加环境变量、其他系统也如是）
##### Working with Multiple Environments
> TODO


### Build web UI and web APIs using ASP.NET Core MVC
 * MVC
 * Razor
 * Tag Helpers
 * Model Validation
 * Formatting Response Data.json,xml

### Client-Side Development
 * AngularJS
 * Bootstrap
 * Backbone
 * KnockoutJS
 

### lession 2 利用VS2015开发项目
> 后补

### lession 3 发布到IIS上运行NetCore项目
> IIS 上运行NetCore项目是有版本限制的。官方给的说明是：https://docs.asp.net/en/latest/publishing/iis.html
> 
> The following operating systems are supported:
>  * Windows 7 and newer
>  * Windows Server 2008 R2 and newer*

#### 简单几个步骤是：
* 安装IIS;(忽略步骤)
*  Install the .NET Core Windows Server Hosting bundle；https://go.microsoft.com/fwlink/?LinkId=817246
   *  Install the .NET Core Windows Server Hosting bundle on the server. The bundle will install the .NET Core Runtime, .NET Core Library, and the ASP.NET Core Module. The module creates the reverse-proxy between IIS and the Kestrel server.
   *  Execute iisreset at the command line or restart the server to pickup changes to the system PATH.
* Enabling the IISIntegration components，主要是在Program.cs中```.UseIISIntegration()``` // IIS扩展运行，需要在IIS上安装一个扩展
* 如果发布到IIS上，还需要一个工具```Microsoft.AspNetCore.Server.IISIntegration.Tools```;
* 最重要的一步就是，发布项目（我是以文件系统的形式发布的），需要在创建站点时，指向这个目录。比如我的：```D:\TodoList\Release\PublishOutput```;
* 另外就是，在应用程序池设置时，需要设置为“无托管代码”的集成形式；
* 最后就是浏览你的NetCore站点了；

### lession 4 使用自定义配置文件设置server.urls,托管多个端口
> 需要在Program.cs中，引入配置文件；比如

```C#
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
```

* 配置文件如下：
```json
    {
        "server.urls": "http://localhost:5001;http://localhost:5002;http://*:5003"
    }
```

* 后续通过命令，执行```dotnet TodoList.Project.dll``` 就可以看到指定的端口已经被监控了。
```bash
    D:\TodoList.Release>dotnet TodoList.Project.dll
info: Microsoft.EntityFrameworkCore.Storage.Internal.RelationalCommandBuilderFactory[1]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      PRAGMA foreign_keys=ON;
info: Microsoft.EntityFrameworkCore.Storage.Internal.RelationalCommandBuilderFactory[1]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      PRAGMA foreign_keys=ON;
info: Microsoft.EntityFrameworkCore.Storage.Internal.RelationalCommandBuilderFactory[1]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT COUNT(*) FROM "sqlite_master" WHERE "type" = 'table' AND "rootpage" IS NOT NULL;
info: Microsoft.Extensions.DependencyInjection.DataProtectionServices[0]
      User profile is available. Using 'C:\Users\Administrator\AppData\Local\ASP.NET\DataProtection-Keys' 
    as key repository and Windows DPAPI to encrypt keys at
 rest.
Hosting environment: Production
Content root path: D:\TodoList.Release
Now listening on: http://localhost:5001
Now listening on: http://localhost:5002
Now listening on: http://*:5003
Application started. Press Ctrl+C to shut down.
```

* 另外，netcore可以指定很多运行环境，通过设置runtimes环境，Nuget会自动下载对应系统环境下依赖包，实现跨平台的发布：
  ```json
  "runtimes": {
        "win7-x64": {},
        //"win7-x86": {},
        //"osx.10.10-x64": {},
        //"osx.10.11-x64": {},
        "ubuntu.16.04-x64": {} //,
        //"centos.7-x64": {}
  },
 ```