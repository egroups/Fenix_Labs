using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sistema.Startup))]
namespace sistema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
