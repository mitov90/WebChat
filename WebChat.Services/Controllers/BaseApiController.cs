namespace WebChat.Services.Controllers
{
    using System.Web.Http;

    using WebChat.Data;
    using WebChat.Services.Helpers;

    public class BaseApiController : ApiController
    {
        public BaseApiController(IUserIdProvider userProvider, IWebChatData data)
        {
            this.UserProvider = userProvider;
            this.Data = data;
        }

        protected IWebChatData Data { get; private set; }

        protected IUserIdProvider UserProvider { get; private set; }
    }
}