using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiContrib.Formatting.Jsonp;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using CinimaServer.Tools;
namespace CinimaServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Cấu hình swagger

            //SwaggerConfigModel.Register(GlobalConfiguration.Configuration);
            //SwaggerConfig.Register();
            //ConfigureAuth();

        }
        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            }
        }
        private void ConfigureAuth()
        {
            string secretKey = "KHAI_TECHX_KHAI_TECHX_KHAI_TECHX_KHAI_TECHX_KHAI_TECHX_KHAI_TECHX_KHAI_TECHX";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "14120",
                ValidAudience = "KAITOKIDO",
                IssuerSigningKey = key
            };

            GlobalConfiguration.Configuration.Filters.Add(new System.Web.Http.AuthorizeAttribute());
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }
    }
}
