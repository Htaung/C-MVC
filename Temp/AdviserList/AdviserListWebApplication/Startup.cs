using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdviserListWebApplication.Startup))]
namespace AdviserListWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
