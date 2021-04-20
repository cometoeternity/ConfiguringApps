using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps
{
    public class Startup
    {
        /*Приложение запускается -> Создаётся экземпляр Startup -> Вызывается метод ConfigureServices ->
        Вызывается метод Configure -> Начинается обработка запросов*/
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Создание служб приложения.
        public void ConfigureServices(IServiceCollection services)
        {
            //Подключение инфраструктуры MVC.
            services.AddMvc();
            //Пример службы для отслеживания времени выполнения приложения, которая может выполняться во
            //всех частях приложения.
            services.AddSingleton<UptimeService>();
        }

        // Настройка конвейера запросов, который представляет собой набор компонентов (middleware, промежуточное ПО),
        // используемых для обработки входящих HTTP-запросов и генерации ответов на них.

        // IApplicationBuilder - этот интерфейс определяет функциональность, требующуюся для
        // настройки конвейера промежуточного ПО приложения.

        // IWebHostEnviroment - этот интерфейс определяет функциональность, необходимую для 
        // различения типов сред, таких как среда разработки и производственная среда.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ////Использование промежуточного ПО для редактирования ответов
            //app.UseMiddleware<ErrorMiddleware>();
            ////Использование промежуточного ПО для редактирования запросов
            //app.UseMiddleware<BrowserTypeMiddleware>();
            ////Использование промежуточного ПО для обхода.
            //app.UseMiddleware<ShortCircuitMiddleware>();
            ////Использование специального компонента промежуточного ПО
            //app.UseMiddleware<ContentMiddleware>();

            //env.ApplicationName = ""; //Это свойство возвращает имя приложения, установленное размещающей платформой
            //env.EnvironmentName = ""; //Это свойство возвращает строку, которвя описывает текущую среду
            //(среду разработки(Development), подготовительную среду (Staging) и
            //производственную среду (Production).
            //env.ContentRootPath = ""; //Это свойство возвращает путь, по которому находятся файлы содержимого и конфигурации приложения.
            //env.WebRootPath = "";     //Это свойство возвращает строку, указывающую каталог статических файлов (wwwroot)


            if (env.IsDevelopment())
            {
               app.UseDeveloperExceptionPage();  //Настраивает компонент промежуточного ПО для обработки ошибок, который
            //который отображает детали исключения в ответе, в том числе трассировочную информацию.
               app.UseStatusCodePages();         //Метод добавляет к ответам, не имеющим содержимого описательные сообщения.
               app.UseBrowserLink();
            }
                else
            {
                app.UseExceptionHandler("/Error"); //Настройка обработку ошибок, позволяющую отображать специальные отображения ошибок
            //которое не раскрывает особенности внутренней работы приложения. Аргументом является URL
            //но который должен быть перенаправлен клиент, чтобы получить сообщение об ошибке.
                app.UseHsts();
            }

            ////Обычный для многих приложений порядок промежуточного ПО.

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //// app.UseCookiePolicy();
            app.UseRouting();
            //// app.UseRequestLocalization();
            //// app.UseCors();
            //app.UseAuthentication();
            //app.UseAuthorization();
            //// app.UseSession();
            //// app.UseResponseCompression();
            //// app.UseResponseCaching();

            //app.UseEndpoints(endpoints =>
            //{
            //    //Выбор стандартоного пути для MVC
            //    endpoints.MapDefaultControllerRoute();
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
