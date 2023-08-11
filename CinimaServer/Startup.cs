using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(CinimaServer.Startup))]

namespace CinimaServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

       
    }
}
