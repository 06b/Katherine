using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Katherine.Startup))]

namespace Katherine
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}
