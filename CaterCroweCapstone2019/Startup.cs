using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaterCroweCapstone2019.Startup))]
namespace CaterCroweCapstone2019
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
