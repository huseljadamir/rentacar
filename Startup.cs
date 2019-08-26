using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LMXRentACar.Startup))]
namespace LMXRentACar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
