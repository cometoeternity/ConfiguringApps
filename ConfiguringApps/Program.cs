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
        //����� ����� ���������� netcore 2.1
        //public static void Main(string[] args)
        //{
        //    BuildWebHost(args).Run();
        //}

        //public static IWebHost BuildWebHost (string [] args)
        //{
        //    return new WebHostBuilder()
        //        //����� ������������� ���-������ Kestrel
        //        .UseKestrel()
        //        //����� ������������� �������� ������� ��� ����������, ������� ����������� ��� �������� ������ �������������
        //        //� �������� ������������ �����������, ������ ��� ����� css, images, JavaScript
        //        .UseContentRoot(Directory.GetCurrentDirectory())
        //        //����� ������������ ��� ���������� ���������������� ������ ����������
        //        .ConfigureAppConfiguration((hostingContext, config) =>
        //    {
        //        var env = hostingContext.HostingEnvironment;
        //        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
        //        if (env.IsDevelopment())
        //        {
        //            var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
        //            if (appAssembly != null)
        //            {
        //                //����� ����������� ��� �������� ����������������� ������ �� ��������� ������ ����.
        //                config.AddUserSecrets(appAssembly, optional: true);
        //            }
        //        }
        //        config.AddEnvironmentVariables();
        //        if (args != null)
        //        {
        //            config.AddCommandLine(args);
        //        }
        //    })  //����� ��������� ����������������� ����������� � ������� ��� ����������
        //        .ConfigureLogging((hostingContext, logging) =>
        //    {
        //        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        //        logging.AddConsole();
        //        logging.AddDebug();
        //    })  //����� �������� ���������� � IIS � IIS Express
        //        .UseIISIntegration()
        //        //����� ����������� ��� ���������������� ��������� ������������
        //        .UseDefaultServiceProvider((context, options) =>
        //    {
        //        options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
        //    })  //����� ��������� �����, ������� ����� �������������� ��� ����������������.
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
