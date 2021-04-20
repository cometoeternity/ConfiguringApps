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
        /*���������� ����������� -> �������� ��������� Startup -> ���������� ����� ConfigureServices ->
        ���������� ����� Configure -> ���������� ��������� ��������*/
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //�������� ����� ����������.
        public void ConfigureServices(IServiceCollection services)
        {
            //����������� �������������� MVC.
            services.AddMvc();
            //������ ������ ��� ������������ ������� ���������� ����������, ������� ����� ����������� ��
            //���� ������ ����������.
            services.AddSingleton<UptimeService>();
        }

        // ��������� ��������� ��������, ������� ������������ ����� ����� ����������� (middleware, ������������� ��),
        // ������������ ��� ��������� �������� HTTP-�������� � ��������� ������� �� ���.

        // IApplicationBuilder - ���� ��������� ���������� ����������������, ����������� ���
        // ��������� ��������� �������������� �� ����������.

        // IWebHostEnviroment - ���� ��������� ���������� ����������������, ����������� ��� 
        // ���������� ����� ����, ����� ��� ����� ���������� � ���������������� �����.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ////������������� �������������� �� ��� �������������� �������
            //app.UseMiddleware<ErrorMiddleware>();
            ////������������� �������������� �� ��� �������������� ��������
            //app.UseMiddleware<BrowserTypeMiddleware>();
            ////������������� �������������� �� ��� ������.
            //app.UseMiddleware<ShortCircuitMiddleware>();
            ////������������� ������������ ���������� �������������� ��
            //app.UseMiddleware<ContentMiddleware>();

            //env.ApplicationName = ""; //��� �������� ���������� ��� ����������, ������������� ����������� ����������
            //env.EnvironmentName = ""; //��� �������� ���������� ������, ������� ��������� ������� �����
            //(����� ����������(Development), ���������������� ����� (Staging) �
            //���������������� ����� (Production).
            //env.ContentRootPath = ""; //��� �������� ���������� ����, �� �������� ��������� ����� ����������� � ������������ ����������.
            //env.WebRootPath = "";     //��� �������� ���������� ������, ����������� ������� ����������� ������ (wwwroot)


            if (env.IsDevelopment())
            {
               app.UseDeveloperExceptionPage();  //����������� ��������� �������������� �� ��� ��������� ������, �������
            //������� ���������� ������ ���������� � ������, � ��� ����� �������������� ����������.
               app.UseStatusCodePages();         //����� ��������� � �������, �� ������� ����������� ������������ ���������.
               app.UseBrowserLink();
            }
                else
            {
                app.UseExceptionHandler("/Error"); //��������� ��������� ������, ����������� ���������� ����������� ����������� ������
            //������� �� ���������� ����������� ���������� ������ ����������. ���������� �������� URL
            //�� ������� ������ ���� ������������� ������, ����� �������� ��������� �� ������.
                app.UseHsts();
            }

            ////������� ��� ������ ���������� ������� �������������� ��.

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
            //    //����� ������������� ���� ��� MVC
            //    endpoints.MapDefaultControllerRoute();
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
