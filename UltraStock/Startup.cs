using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UltraStock.Startup))]
namespace UltraStock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
