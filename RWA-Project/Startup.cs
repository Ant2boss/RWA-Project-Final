using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RWA_Project.Startup))]
namespace RWA_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
