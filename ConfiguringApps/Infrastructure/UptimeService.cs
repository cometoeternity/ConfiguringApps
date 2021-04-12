using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class UptimeService
    {
        private Stopwatch timer;

        public long Uptime => timer.ElapsedMilliseconds;

        public UptimeService()
        {
            timer = Stopwatch.StartNew();
        }

        
    }
}
