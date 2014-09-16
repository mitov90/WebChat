using Microsoft.Owin;

using WebChat.Services;

[assembly: OwinStartup(typeof(Startup))]

namespace WebChat.Services
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}