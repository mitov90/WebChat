namespace WebChat.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using WebChat.Data;
    using WebChat.Models;
    using WebChat.Services.Helpers;
    using WebChat.Services.ViewModels;

    //[Authorize]
    [EnableCors("*", "*", "*")]
    public class NotificationController : BaseApiController
    {
        private const string NotificationSubscribeKey = "sub-c-34433516-3e64-11e4-8c81-02ee2ddab7fe";
        private const string NotificationPublishKey = "pub-c-6576e5b7-0139-4662-a73b-50c3d7339d4d";

        // GET api/values
        public NotificationController(IUserIdProvider userProvider, IWebChatData data)
            : base(userProvider, data)
        {}

        [HttpGet]
        public IHttpActionResult GetSubscribeKey()
        {
            return this.Ok(NotificationSubscribeKey);            
        }

        // This should be removed. Used only for testing. In the final version only the web service should have the publish key, not the clients.
        [HttpGet]
        public IHttpActionResult GetPublishKey()
        {
            return this.Ok(NotificationPublishKey);            
        }

    }
}