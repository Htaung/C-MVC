using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBFirst.Startup))]
namespace DBFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
