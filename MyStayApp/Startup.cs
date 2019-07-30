using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyStayApp.Startup))]
namespace MyStayApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
