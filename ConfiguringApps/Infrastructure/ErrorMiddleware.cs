using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{

    //Тип промежуточного ПО оперирует на ответах, генерируемых другими компонентами в конвейере.
    //Это полезно для регистрации в журнале деталей запросов и их ответов или для обработки ошибок.
    public class ErrorMiddleware
    {
        public RequestDelegate nextDelegate;
        public ErrorMiddleware(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }
        public async Task Invoke (HttpContext httpContext)
        {
            await nextDelegate.Invoke(httpContext);
            if(httpContext.Response.StatusCode==403)
            {
                await httpContext.Response.WriteAsync("Edge not supported", Encoding.UTF8);
            }
            else if (httpContext.Response.StatusCode==404)
            {
                await httpContext.Response.WriteAsync("No content middleware response", Encoding.UTF8);
            }
        }
    }
    //Компонент не заимтересован в запросе до тех пор, пока он не пройдет свой путь через конвейер
    //промежуточного ПО и не будет сгенерирован ответ. Если кодом состояния будет 403 или 404, тогда
    //к ответу добавляется описательное сообщение. Все другие ответы игнорируются.
}
