using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Arcade.Startup))]
namespace Arcade
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
