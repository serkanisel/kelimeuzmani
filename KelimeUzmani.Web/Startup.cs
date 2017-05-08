using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KelimeUzmani.Web.Startup))]
namespace KelimeUzmani.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
