### TODOList
 * Startup
 * Configuration
 * IApplicationBuilder
 * IConfigurationRoot
 * Middleware
 * ILoggingFactory


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
