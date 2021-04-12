using ConfiguringApps.Infrastructure;
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
        /*���������� ����������� -> �������� ��������� Startup -> ���������� ����� ConfigureServices ->
        ���������� ����� Configure -> ���������� ��������� ��������*/

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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //������������� �������������� �� ��� ������.
            app.UseMiddleware<ShortCircuitMiddleware>();
            //������������� ������������ ���������� �������������� ��
            app.UseMiddleware<ContentMiddleware>();
            

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseBrowserLink();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    app.UseHsts();
            //}

            ////������� ��� ������ ���������� ������� �������������� ��.

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //// app.UseCookiePolicy();
            //app.UseRouting();
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
        }
    }
}
