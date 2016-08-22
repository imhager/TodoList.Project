### TODOList
 * Startup��
   * http://asp.net-hacker.rocks/2016/02/17/dependency-injection-in-aspnetcore.html
 * Configuration
 * IApplicationBuilder
 * IConfigurationRoot
 * Middleware
 * ILoggingFactory
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
