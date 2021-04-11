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
        #region netcore 2.1
        //Точка входа приложения netcore 2.1
        //public static void Main(string[] args)
        //{
        //    BuildWebHost(args).Run();
        //}

        //public static IWebHost BuildWebHost (string [] args)
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
        //        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
        //        if (env.IsDevelopment())
        //        {
        //            var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
        //            if (appAssembly != null)
        //            {
        //                //Метод применяется для хранения конфиденциалльных данных за пределами файлов кода.
        //                config.AddUserSecrets(appAssembly, optional: true);
        //            }
        //        }
        //        config.AddEnvironmentVariables();
        //        if (args != null)
        //        {
        //            config.AddCommandLine(args);
        //        }
        //    })  //Метод позволяет сфконфигурировать регистрацию в журнале для приложения
        //        .ConfigureLogging((hostingContext, logging) =>
        //    {
        //        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        //        logging.AddConsole();
        //        logging.AddDebug();
        //    })  //Метод включает интеграцию с IIS и IIS Express
        //        .UseIISIntegration()
        //        //Метод применяется для конфигурирования внедрения зависимостей
        //        .UseDefaultServiceProvider((context, options) =>
        //    {
        //        options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
        //    })  //Метод указывает класс, который будет использоваться для конфигурирования.
        //        .UseStartup<Startup>().Build();
        //}
        #endregion

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
