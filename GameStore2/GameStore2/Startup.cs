using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameStore2.Startup))]
namespace GameStore2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
