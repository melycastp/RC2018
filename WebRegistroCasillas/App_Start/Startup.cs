using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(WebRegistroCasillas.App_Start.Startup))]

namespace WebRegistroCasillas.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {             // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888            
            app.UseCookieAuthentication(
                new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Home/Index"),
                    Provider = new CookieAuthenticationProvider { OnApplyRedirect = OnApplyRedirect }
                });

        }

        public static void OnApplyRedirect(CookieApplyRedirectContext context)
        {
            var url = HttpContext.Current.Request.Url.AbsoluteUri;
            string redirectUrl = "/Home/Index";
            context.Response.Redirect(redirectUrl);
        }
    }
}