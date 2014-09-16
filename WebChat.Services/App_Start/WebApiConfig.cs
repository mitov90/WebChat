namespace WebChat.Services
{
    using System.Web.Http;
    using System.Linq;

    using Microsoft.Owin.Security.OAuth;

    using WebChat.Data;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            WebChatData data = new WebChatData(new WebChatDbContext());
            var files = data.Files.All().ToList();
            var a = 1;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }
    }
}