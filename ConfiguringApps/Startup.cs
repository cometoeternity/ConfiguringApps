using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        //Создание служб приложения.
        public void ConfigureServices(IServiceCollection services)
        {
            //Подключение инфраструктуры MVC.
            services.AddMvc();
        }

        // Настройка конвейера запросов, который представляет собой набор компонентов (middleware, промежуточное ПО),
        // используемых для обработки входящих HTTP-запросов и генерации ответов на них.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Выбор стандартоного пути для MVC
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
