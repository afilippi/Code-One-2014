﻿using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(CodeOneFinancialManagerMK2.Startup))]
namespace CodeOneFinancialManagerMK2.Hubs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}