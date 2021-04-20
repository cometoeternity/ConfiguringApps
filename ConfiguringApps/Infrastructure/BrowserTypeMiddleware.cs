using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{

    //Промежуточное ПО для редактирования запросов. Этот тип не генерирует ответ, взамен
    //компонент изменяет запросы перед тем, как они достигнут других компонентов, которые стоят дальше в цепочке.
    //Применяется преемущественно в целях интеграции с платформой, чтобы обогатить представление ASP.NET Core запроса
    //HTTP средствами, специфическими для платформы. Он также может использоваться при подготовке запросов, чтобы
    //их легче было обрабатывать последующими компонентами.
    public class BrowserTypeMiddleware
    {
        private RequestDelegate nextDelegate;
        public BrowserTypeMiddleware(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["EdgeBrowser"] = httpContext.Request.Headers["User-Agent"].Any(v => v.ToLower().Contains("edg"));
            await nextDelegate.Invoke(httpContext);
        }
    }
    //Новый компонент инспектирует заголовок User-Agent(браузера) запроса и ищет в нем элемент edg, что предполагает
    //возможность выдачи запроса браузером Edge. Объект HttpContext предоставляет через свойство Items словать, который
    //применяется дле передачи данных между компонентами, и результат поиска в заголовке Headers сохраняется с ключом EdgeBrowser.
}
