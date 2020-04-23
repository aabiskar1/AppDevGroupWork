using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApplicationDevGroupWork.Startup))]
namespace ApplicationDevGroupWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
