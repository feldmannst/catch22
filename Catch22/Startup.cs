using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Catch22.Startup))]
namespace Catch22
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
