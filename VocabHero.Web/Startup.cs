using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VocabHero.Web.Startup))]
namespace VocabHero.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            
        }
    }
}
