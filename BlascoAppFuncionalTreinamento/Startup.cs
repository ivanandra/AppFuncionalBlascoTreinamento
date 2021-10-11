using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlascoAppFuncionalTreinamento.Startup))]
namespace BlascoAppFuncionalTreinamento
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
