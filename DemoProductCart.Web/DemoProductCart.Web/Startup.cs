using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoProductCart.Web.Startup))]
namespace DemoProductCart.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
