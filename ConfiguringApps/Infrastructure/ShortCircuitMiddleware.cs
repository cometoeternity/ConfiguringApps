using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    // Создание промежуточного По для обхода.
    // Перехватывает запросы до того, как они достигнут компонентов
    // для генерации содержимого, чтобы обойти процесс прохождения конвейера,
    // часто в целях производительности.

    // В данном случае, если заголовок User-Agent (идентификация браузера) содержит элемент edg (Microsoft EDGE)
    // тогда компонент устанавливает код ошибки 403 и не направляет запрос следующему компоненту ПО.
    public class ShortCircuitMiddleware
    {
        private RequestDelegate nextDelegate;
        public ShortCircuitMiddleware(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }
        public async Task Invoke (HttpContext httpContext)
        {
            if(httpContext.Items["EdgeBrowser"] as bool? == true) // Демонстрация взаимодействия компонентов между собой.
            {
                httpContext.Response.StatusCode = 403;
            }
            else 
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
