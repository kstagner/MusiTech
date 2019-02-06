using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Musi_Tech_.Startup))]
namespace Musi_Tech_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
