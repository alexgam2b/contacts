# Контакты

Тренировочный проект записной книги контактов.

## Используемые технологии

Фреймворк:

.Net Framework 4.7.2

Установленные пакеты:

Antlr 3.5.0.2 <br/>
bootstrap 3.4.1 <br/>
EntityFramework 6.4.4 <br/>
jQuery 3.4.1 <br/>
jQuery.Validation 1.17.0 <br/>
Microsoft.AspNet.Mvc 5.2.7 <br/>
Microsoft.AspNet.Razor 3.2.7 <br/>
Microsoft.AspNet.Web.Optimization 1.1.3 <br/>
Microsoft.AspNet.WebPages 3.2.7 <br/>
Microsoft.CodeDom.Providers.DotNetCompilerPlatform 2.0.1 <br/>
Microsoft.jQuery.Unobtrusive.Validation 3.2.11 <br/>
Microsoft.Web.Infrastructure 1.0.0 <br/>
Modernizr 2.8.3 <br/>
MSTest.TestAdapter 1.2.0 <br/>
MSTest.TestFramework 1.2.0 <br/>
Newtonsoft.Json 12.0.2 <br/>
WebGrease 1.6.0 <br/>

СУБД:

Microsoft SQL Server Express (64-bit) 15.0.2070.41

## Особенности развертывания приложения

База данных создается в момент первого обращения.
Необходимо настроить строку подключения connectionString в файле web.config
При создании базы заполняются предварительные данные 
для таблицы типов контактов. Класс - App_start\DataInitializer.cs

Начальные тестовые данные находятся в классе - Contacts.Tests\Data\DataSeed.cs
Чтобы запустить тест, необходимо настроить строку подключения connectionString к БД в файле web.config

При создании проекта понимание его архитектуры пришло не сразу, и
тестов, увы, не написал. Не все идеи удалось довести до требуемого уровня...
