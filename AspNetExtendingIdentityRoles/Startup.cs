using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HNWebPortal.Startup))]
namespace HNWebPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
