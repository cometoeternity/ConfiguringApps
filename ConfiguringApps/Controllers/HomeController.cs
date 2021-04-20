﻿using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;

        public HomeController(UptimeService uptime)
        {
            this.uptime = uptime;
        }

        public ViewResult Index(bool throwException = false)
        {
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