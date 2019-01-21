using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cashAccounting.Startup))]
namespace cashAccounting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
