using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Touche.Startup))]
namespace Touche
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
