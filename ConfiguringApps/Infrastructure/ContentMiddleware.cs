using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    //Промежуточное ПО для генерации содержимого для клиентов и использование служб
    //в промежуточном ПО.
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        private UptimeService uptimeService;

        public ContentMiddleware(RequestDelegate nextDelegate, UptimeService uptimeService) 
        {
            this.nextDelegate = nextDelegate;
            this.uptimeService = uptimeService;
        }
        public async Task Invoke (HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync($"This is from the content middleware, Uptime is {uptimeService.Uptime}ms", Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
