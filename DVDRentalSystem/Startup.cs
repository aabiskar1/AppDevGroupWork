using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DVDRentalSystem.Startup))]
namespace DVDRentalSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
