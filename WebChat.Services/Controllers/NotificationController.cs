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
    using WebChat.NotificationManager;
    using WebChat.Services.Helpers;
    using WebChat.Services.ViewModels;

    //[Authorize]
    [EnableCors("*", "*", "*")]
    public class NotificationController : BaseApiController
    {
        private INotificationManager notificationManager;

        // GET api/values
        public NotificationController(IUserIdProvider userProvider, IWebChatData data)
            : base(userProvider, data)
        {
            this.notificationManager = PubNubNotificationManager.Instance;
        }

        [HttpGet]
        public IHttpActionResult GetSubscribeKey()
        {
            return this.Ok(this.notificationManager.SubscribeKey);            
        }

        // This should be removed. Used only for testing. In the final version only the web service should have the publish key, not the clients.
        /*[HttpGet]
        public IHttpActionResult GetPublishKey()
        {
            return this.Ok(this.notificationManager.PublishKey);            
        }*/

    }
}