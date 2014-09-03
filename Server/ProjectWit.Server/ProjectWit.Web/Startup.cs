using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectWit.Web.Startup))]
namespace ProjectWit.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
