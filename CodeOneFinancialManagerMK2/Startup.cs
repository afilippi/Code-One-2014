using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeOneFinancialManagerMK2.Startup))]
namespace CodeOneFinancialManagerMK2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
