using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConsomiTounsiFront.Startup))]
namespace ConsomiTounsiFront
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
