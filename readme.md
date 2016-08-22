### TODOList
 * Startup：
   * http://asp.net-hacker.rocks/2016/02/17/dependency-injection-in-aspnetcore.html
 * Configuration
 * IApplicationBuilder
 * IConfigurationRoot
 * Middleware
 * ILoggingFactory
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
