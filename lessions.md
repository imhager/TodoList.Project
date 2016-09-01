### lession 1 ��ʶasp.net core
**���ܸĽ��㣺**
   * A unified story for building web UI and web APIs һ��ͳһ�Ĺ���web UI��web api��ƽ̨
   * Integration of modern client-side frameworks and development workflows �Ƚ����еĿͻ��˿�ܺͿ����������ļ���
   * A cloud-ready environment-based configuration system �����Ļ����ƻ��������ļ���ϵͳ
   * Built-in dependency injection ��������ע��
   * New light-weight and modular HTTP request pipeline �µ���������ģ�黯��http����ܵ�
   * Ability to host on IIS or self-host in your own process ����IIS����self-host������
   * Built on .NET Core, which supports true side-by-side app versioning ����֧��������Ӧ�ó���汾����
   * Ships entirely as NuGet packages ����nuget������
   * New tooling that simplifies modern web development �µļ�Web�����Ĺ���
   * Build and run cross-platform ASP.NET apps on Windows, Mac and Linux ���ڶ�ƽ̨����������windows��mac��linuxƽ̨
   * Open source and community focused ��Դ������֧��

### Startup
> Starpup ���Ƕ���������������������Ҫ�ķ���Services���ĵط���Startup��������Ϊpublic�����Ұ�������������
```c#
public class Startup
{
    // ����һЩӦ�ó�������Ҫ�õ���services������Mvc coreFramework,Entity frameworkcore��identity��
    // �˷���������DIContainer��ע����Ҫ��service����
    public void ConfigureServices(IServiceCollection services)
    {
    }
    // ����һЩ�м����middleware��,������չ��������������env,loggerFactory��
    public void Configure(IApplicationBuilder app[, IHostingEnvironment env, ILoggerFactory loggerFactory])
    {
    }
}
```

### Services
> �������Ϊ��һ���������������ΪӦ�ó����ṩ���ѡ�aspnet core���Դ���IOC ������Ĭ����֧�ֹ��캯��ע�뷽ʽ����ʵ��Ҳ���Ը���Ϊ�Լ���Ϥ��DI container������Autofac�ȡ�
> 

### Middleware
> �м������Ҫ�����ڴ���ܵ����󡣱�������IP�����¼��Ȩ���ж�����־��¼�ȵȣ��������ؿ����Ƿ�������´������󣬻���ֱ�����ط��ء�
> һ������Startup.Configure�����У�ʹ�á�UseXXX���ķ�ʽ����һ������IApplicationBuilder����չ������
> ���磺
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
> ����Զ����Լ���middleware����Ҫ�ر�ע��ľ��������㣬һ�����������Ĵ���requestDelegate��һ���Ƕ��������HttpContext�����ĵ�Invoke������
> Ȼ��һ������```IApplicationBuilder```�ľ�̬��չ��������```UseMiddleware<T>()```ע���ȥ���ɡ�

### Servers
> asp.net core�ṩ�˳��˻���IIS֮��Ŀ�ƽ̨�����ܣ�����kestrel.�������IIS�����У���Ҫ��װһ������IIS����չģ�顰HttpPlatformHandler����IIS7.5+����
> ��ʵ��asp.netcore����������������ֻ��ת������Ȼ���ɴ����Ӧ�ó�����ϳ�һ��httpcontext��
> 
> The HttpPlatformHandler is a new component that connects IIS with your ASP.NET Core application. You can get that from the following download links.

 * 64 bit HttpPlatformHandler http://go.microsoft.com/fwlink/?LinkID=690721
 * 32 bit HttpPlatformHandler http://go.microsoft.com/fwlink/?LinkId=690722

### Configuration
> Asp.Net Coreʹ�õ���һ���µ�����ģ��������KV��ֵ�ԡ��µ�����ģ�ͼȲ��ǻ���```System.Configuration```Ҳ���ǻ���������Ϥ��```web.config```;
> ����һ�������ṩ�ߣ�providers�����ڽ��������ṩ�ߣ�֧�ֺܶ��ʽ������json��xml��ini��������֧�ֻ�������������ͬ������Զ������Լ��������ṩ�ߡ�

### Environments
> ��������ʵ�����ǳ�˵�ġ���������Development��������ʽ����Production��.���Ը������õĻ�������ֵ��ͬ��������ѡ���Ӧ�����á�
> ��VS2015�У�������Ŀʱ��Ĭ�ϻ�����һ���й��ڻ����ı�����```ASPNETCORE_ENVIRONMENT```����ͬʱ��Ĭ�ϱ�ָ��Ϊ�ˡ�Development��������Դ���Ŀ�����У��ҵ������ԡ�Tab������Ϳ��Կ�����
> ����������ַ�ʽ���ã�Ҳ�������ó�ϵͳ����Ļ�������������windows�����ӻ�������������ϵͳҲ���ǣ�
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
 

### lession 2 ����VS2015������Ŀ
> ��

### lession 3 ������IIS������NetCore��Ŀ
> IIS ������NetCore��Ŀ���а汾���Ƶġ��ٷ�����˵���ǣ�https://docs.asp.net/en/latest/publishing/iis.html
> 
> The following operating systems are supported:
>  * Windows 7 and newer
>  * Windows Server 2008 R2 and newer*

#### �򵥼��������ǣ�
* ��װIIS;(���Բ���)
*  Install the .NET Core Windows Server Hosting bundle��https://go.microsoft.com/fwlink/?LinkId=817246
   *  Install the .NET Core Windows Server Hosting bundle on the server. The bundle will install the .NET Core Runtime, .NET Core Library, and the ASP.NET Core Module. The module creates the reverse-proxy between IIS and the Kestrel server.
   *  Execute iisreset at the command line or restart the server to pickup changes to the system PATH.
* Enabling the IISIntegration components����Ҫ����Program.cs��```.UseIISIntegration()``` // IIS��չ���У���Ҫ��IIS�ϰ�װһ����չ
* ���������IIS�ϣ�����Ҫһ������```Microsoft.AspNetCore.Server.IISIntegration.Tools```;
* ����Ҫ��һ�����ǣ�������Ŀ���������ļ�ϵͳ����ʽ�����ģ�����Ҫ�ڴ���վ��ʱ��ָ�����Ŀ¼�������ҵģ�```D:\TodoList\Release\PublishOutput```;
* ������ǣ���Ӧ�ó��������ʱ����Ҫ����Ϊ�����йܴ��롱�ļ�����ʽ��
* ������������NetCoreվ���ˣ�

### lession 4 ʹ���Զ��������ļ�����server.urls,�йܶ���˿�
> ��Ҫ��Program.cs�У����������ļ�������

```C#
     public static void Main(string[] args)
        {

            //��ʽһ�������ļ� �Զ���server.urls
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/hostsettings.Development.json", optional: true, reloadOnChange: true).Build();


            // ��ʽ������Ҫ����Microsoft.Extensions.Configuration.CommandLine
            // Ȼ��ִ��dotnet run --server.urls "http://localhost:5001;http://localhost:5002;http://*:5003"
            //var config = new ConfigurationBuilder()
            //   .AddCommandLine(args)
            //   .Build();

            var host = new WebHostBuilder()
                .UseConfiguration(config) // ʹ���Զ���server.urls�����Կ�������˿�
                //.UseUrls("http://localhost:9527;http://localhost:9528;http://*:9529")
                .UseKestrel() // ��ƽ̨����
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration() // IIS��չ���У���Ҫ��IIS�ϰ�װһ����չ
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
```

* �����ļ����£�
```json
    {
        "server.urls": "http://localhost:5001;http://localhost:5002;http://*:5003"
    }
```

* ����ͨ�����ִ��```dotnet TodoList.Project.dll``` �Ϳ��Կ���ָ���Ķ˿��Ѿ�������ˡ�
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

* ���⣬netcore����ָ���ܶ����л�����ͨ������runtimes������Nuget���Զ����ض�Ӧϵͳ��������������ʵ�ֿ�ƽ̨�ķ�����
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