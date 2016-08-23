### 列表内容
> https://docs.asp.net/en/latest/fundamentals/index.html
* Middleware
* Working with Static Files
* Routing
* Error Handling
* Globalization and localization
* Configuration
* Logging
* File Providers
* Dependency Injection
* Working with Multiple Environments
* Hosting
* Managing Application State
* Servers
* Request Features
* Open Web Interface for .NET (OWIN)
* Choosing the Right .NET For You on the Server
* taghelper
  * 以大写字母分割，如果是由多个字母组成，那么就会把单词变成全小写，然后用-分割开来；
      * 比如：CountryListTagHelper----> country-list;
      * 如果是：CountrylistTagHelper----> countrylist;
  * 特别注意的是：需要在引用自定义TagHelper的页面，引入以下代码：(因为不了解嘛，所以踩了坑了，好久没好用)
  
```c#  
@addTagHelper *,TodoList.Project
// 格式：@addTagHelper typeName,AssemblyName
```



### TODOList
 * **Startup**：
   * 程序启动点
   * http://asp.net-hacker.rocks/2016/02/17/dependency-injection-in-aspnetcore.html
 * **Configuration**
   * aa
 * **IApplicationBuilder**
   * aa
 * **IConfigurationRoot**
   * 配置文件
 * **Middleware**
   * 中间件，在pipline处理过程中，可以增加无数个moddleware，也可以提前结束一个请求（比如权限、角色判定、Ip地址检测白名单等）
 * **ILoggingFactory**
   * 日志公用接口，第三方扩展，如果实现了该接口，一样可以使用。比如NLog；（需要引用NLog.Extensions.Logging）

 * **如何使用Autofac替换系统自带的DI**
   * 引入autofac依赖（Autofac、Autofac.Extensions.DependencyInjection）
   * 将ConfigureServices返回值更改为IServiceProvider而不是系统自带的void；（当使用系统的DI工具时，返回值是void）
   * 

### 生命周期说明
 * **Transient**
   * Transient 服务在每次请求时被创建，它最好被用于轻量级无状态服务（如我们的Repository和ApplicationService服务）
 * **Scoped**
   * Scoped 服务在每次请求时被创建，生命周期横贯整次请求
 * **Singleton**
   * 顾名思义，Singleton（单例） 服务在第一次请求时被创建（或者当我们在ConfigureServices中指定创建某一实例并运行方法），其后的每次请求将沿用已创建服务。如果开发者的应用需要单例服务情景，请设计成允许服务容器来对服务生命周期进行操作，而不是手动实现单例设计模式然后由开发者在自定义类中进行操作。


> Sqlite默认Id字段作为主键自增
```sql
CREATE TABLE "TodoUser" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TodoUser" PRIMARY KEY AUTOINCREMENT,
    "Brithday" TEXT NOT NULL,
    "CreateTime" TEXT NOT NULL,
    "NickName" TEXT,
    "QRUrl" TEXT,
    "Sex" INTEGER NOT NULL,
    "UserName" TEXT
);


```
