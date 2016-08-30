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