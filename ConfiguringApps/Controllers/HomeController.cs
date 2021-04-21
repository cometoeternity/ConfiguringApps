using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;
        private ILogger<HomeController> logger;

        public HomeController(UptimeService uptime, ILogger<HomeController> logger)
        {
            this.uptime = uptime;
            this.logger = logger;
        }

        public ViewResult Index(bool throwException = false)
        {
            logger.LogDebug($"Handled {Request.Path} at uptime {uptime.Uptime}");
            if (throwException)
            {
                throw new System.NullReferenceException();
            }
            return View(new Dictionary<string, string>
            {
                ["Message"] = "This is the Index action",
                ["Uptime"] = $"{uptime.Uptime}ms"
            });
        }
        public ViewResult Error()
        {
            return View(nameof(Index), new Dictionary<string, string>
            {
                ["Message"] = "This is Error action"
            }); ;
        }
    }
}