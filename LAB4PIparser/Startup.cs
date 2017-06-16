using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LAB4PIparser.Startup))]
namespace LAB4PIparser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
