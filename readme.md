### �б�����
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
  * �Դ�д��ĸ�ָ������ɶ����ĸ��ɣ���ô�ͻ�ѵ��ʱ��ȫСд��Ȼ����-�ָ����
      * ���磺CountryListTagHelper----> country-list;
      * ����ǣ�CountrylistTagHelper----> countrylist;
  * �ر�ע����ǣ���Ҫ�������Զ���TagHelper��ҳ�棬�������´��룺(��Ϊ���˽�����Բ��˿��ˣ��þ�û����)
  
```c#  
@addTagHelper *,TodoList.Project
// ��ʽ��@addTagHelper typeName,AssemblyName
```



### TODOList
 * **Startup**��
   * ����������
   * http://asp.net-hacker.rocks/2016/02/17/dependency-injection-in-aspnetcore.html
 * **Configuration**
   * aa
 * **IApplicationBuilder**
   * aa
 * **IConfigurationRoot**
   * �����ļ�
 * **Middleware**
   * �м������pipline��������У���������������moddleware��Ҳ������ǰ����һ�����󣨱���Ȩ�ޡ���ɫ�ж���Ip��ַ���������ȣ�
 * **ILoggingFactory**
   * ��־���ýӿڣ���������չ�����ʵ���˸ýӿڣ�һ������ʹ�á�����NLog������Ҫ����NLog.Extensions.Logging��

 * **���ʹ��Autofac�滻ϵͳ�Դ���DI**
   * ����autofac������Autofac��Autofac.Extensions.DependencyInjection��
   * ��ConfigureServices����ֵ����ΪIServiceProvider������ϵͳ�Դ���void������ʹ��ϵͳ��DI����ʱ������ֵ��void��
   * 

### ��������˵��
 * **Transient**
   * Transient ������ÿ������ʱ������������ñ�������������״̬���������ǵ�Repository��ApplicationService����
 * **Scoped**
   * Scoped ������ÿ������ʱ���������������ں����������
 * **Singleton**
   * ����˼�壬Singleton�������� �����ڵ�һ������ʱ�����������ߵ�������ConfigureServices��ָ������ĳһʵ�������з�����������ÿ�����������Ѵ���������������ߵ�Ӧ����Ҫ���������龰������Ƴ���������������Է����������ڽ��в������������ֶ�ʵ�ֵ������ģʽȻ���ɿ��������Զ������н��в�����


> SqliteĬ��Id�ֶ���Ϊ��������
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
