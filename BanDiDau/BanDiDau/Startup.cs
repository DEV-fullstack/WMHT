using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BanDiDau.Startup))]
namespace BanDiDau
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
