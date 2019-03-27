using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(novelconvert.Startup))]
namespace novelconvert
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
