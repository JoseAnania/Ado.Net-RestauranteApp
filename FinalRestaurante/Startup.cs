using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalRestaurante.Startup))]
namespace FinalRestaurante
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
