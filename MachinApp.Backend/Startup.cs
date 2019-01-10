using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MachinApp.Backend.Startup))]
namespace MachinApp.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
