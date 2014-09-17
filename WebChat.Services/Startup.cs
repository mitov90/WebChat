using Microsoft.Owin;

using WebChat.Services;

[assembly: OwinStartup(typeof(Startup))]

namespace WebChat.Services
{
    using System.Reflection;
    using System.Web.Http;

    using Ninject;
    using Ninject.Syntax;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    using Owin;

    using WebChat.Data;
    using WebChat.Services.Helpers;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            StandardKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(BindingRoot kernel)
        {
            kernel.Bind<IWebChatData>().To<WebChatData>()
                  .WithConstructorArgument(
                                           "context", 
                                           c => new WebChatDbContext());

            kernel.Bind<IUserIdProvider>().To<UserIdProvider>();
        }
    }
}