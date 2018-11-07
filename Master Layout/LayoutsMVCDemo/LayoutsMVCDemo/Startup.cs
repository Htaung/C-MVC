using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LayoutsMVCDemo.Startup))]
namespace LayoutsMVCDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
