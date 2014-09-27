using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OceanWechat.Startup))]
namespace OceanWechat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
