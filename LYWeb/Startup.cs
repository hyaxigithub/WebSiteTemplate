using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LYWeb.Startup))]
namespace LYWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
