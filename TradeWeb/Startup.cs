using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TradeWeb.Startup))]
namespace TradeWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
