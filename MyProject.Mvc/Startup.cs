using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyProject.Mvc.Startup))]
namespace MyProject.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
