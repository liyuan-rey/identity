﻿using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Diagnostics;
using Owin;

[assembly: OwinStartup(typeof (IdentityNS.Server.Core.Startup))]

namespace IdentityNS.Server.Core
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
#if DEBUG
            app.UseErrorPage(new ErrorPageOptions
            {
                //Shows the OWIN environment dictionary keys and values.
                //This detail is enabled by default if you are running your app from VS unless disabled in code. 
                ShowEnvironment = true,
                //Hides cookie details
                ShowCookies = true,
                //Shows the lines of code throwing this exception.
                //This detail is enabled by default if you are running your app from VS unless disabled in code. 
                ShowSourceCode = true
            });

            //for test ErrorPage
            //app.Run(async context =>
            //{
            //    throw new Exception("UseErrorPage() demo");
            //    await context.Response.WriteAsync("Error page demo");
            //});
#endif
            app.UseWelcomePage("/");

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}