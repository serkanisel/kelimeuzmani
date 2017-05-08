using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KelimeUzmani.Web.Simple.Startup))]
namespace KelimeUzmani.Web.Simple
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
