using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lsb_03.Startup))]
namespace lsb_03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
