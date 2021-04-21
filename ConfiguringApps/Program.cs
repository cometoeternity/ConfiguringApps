using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ConfiguringApps
{
    public class Program
    {
        //#region netcore 2.1
        //Точка входа приложения netcore 2.1
        //public static void Main(string[] args)
        //{
        //    BuildWebHost(args).Run();
        //}

        //public static IWebHost BuildWebHost(string[] args)
        //{
        //    return new WebHostBuilder()
        //        //Метод конфигурирует веб-сервер Kestrel
        //        .UseKestrel()
        //        //Метод конфигурирует корневой католог для приложения, который применяется для загрузки файлов конфигурациии
        //        //и доставки статического содержимого, такого как файлы css, images, JavaScript
        //        .UseContentRoot(Directory.GetCurrentDirectory())
        //        //Метод используется для подготовки конфигурационных данных приложения
        //        .ConfigureAppConfiguration((hostingContext, config) =>
        //    {
        //        var env = hostingContext.HostingEnvironment;
        //        Этот метод применяетсся для загрузки данных конфигурации из файла JSON.
        //АРГУМЕНТЫ МЕТОДА 1 - ИМЯ ФАЙЛА, 2 - ЯВЛЯКТСЯ ЛИ ФАЙЛ НЕОБЯЗАТЕЛЬНЫМ 3 - ДОЛЖНЫ ЛИ ДАННЫЕ КОНФИГУРАЦИИ ЗАГРУЖАТЬСЯ ПОВТОРНО ЕСЛИ ФАЙЛ ИЗМЕНИТСЯ. 
        //        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
        //        if (env.IsDevelopment())
        //        {
        //            var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
        //            if (appAssembly != null)
        //            {
        //                //Метод применяется для хранения конфиденциалльных данных за пределами файлов кода.
        //                config.AddUserSecrets(appAssembly, optional: true);
        //            }
        //        }
        //        Этот метод используется для загрузки данных конфигурации из переменных среды.
        //        config.AddEnvironmentVariables();
        //        if (args != null)
        //        {
        //            Этот метод применяется для загрузки данных конфигурации из переменных среды.
        //config.AddCommandLine(args);
        //        }
        //    })  //Метод позволяет сфконфигурировать регистрацию в журнале для приложения
        //                .ConfigureLogging((hostingContext, logging) =>
        //            {
        //                Этот метод используется для конфигурирования системы регистрации в журнале с примененнием данных конфигурации
        //                которые были загружены из файла appsettings.json из командной строки либо из переменных среды.
        //                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        //                Этот метод отправляет журнальные сообщения консоли, что удобно в случае запуска приложения с использованием
        //                команды dotnet run
        //                logging.AddConsole();
        //                Этот метод отправляет журнальные сообщения в окно Output во время отладки Visual Studio
        //                logging.AddDebug();
        //                Этот метод отправляет журнальные сообщения в журнал событий Windows, что удобно в ситуации, когда
        //                приложение ASP.NET Core MVC развернуто на сервере Windows и нужно, чтобы сообщения из него смешивалось с 
        //                сообщениями от приложений других типов.  
        //                logging.AddEventLog();

        //            })  //Метод включает интеграцию с IIS и IIS Express
        //                        .UseIISIntegration()
        //                        //Метод применяется для конфигурирования внедрения зависимостей
        //                        .UseDefaultServiceProvider((context, options) =>
        //                    {
        //                        options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
        //                    })  //Метод указывает класс, который будет использоваться для конфигурирования.
        //                        .UseStartup<Startup>().Build();
        //}
        //#endregion

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
