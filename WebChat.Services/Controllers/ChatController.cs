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
    using WebChat.Dropbox;
    using WebChat.Models;
    using WebChat.NotificationManager;
    using WebChat.Services.Helpers;
    using WebChat.Services.ViewModels;

    //[Authorize]
    [EnableCors("*", "*", "*")]
    public class ChatController : BaseApiController
    {
        // GET api/values
        public ChatController(IUserIdProvider userProvider, IWebChatData data)
            : base(userProvider, data)
        {}
/*
        [HttpGet]
        public IQueryable<ViewUser> GetAllUsers()
        {
            return this.Data.Users.All().Select(u => ViewUser.GetData(u));
        }

        [HttpGet]
        public IHttpActionResult GetUserInfo(string id)
        {
            Guid guid;

            if (!Guid.TryParse(id, out guid))
            {
                return this.BadRequest("Invalid Id - invalid guid format");
            }

            User user = this.Data.Users.Find(id);
            if (user == null)
            {
                return this.BadRequest("Invalid Id - user not found");
            }

            return this.Ok(ViewUser.GetData(user));
        }

        [HttpGet]
        public IHttpActionResult GetMessages(string id)
        {
            Guid guid;

            if (!Guid.TryParse(id, out guid))
            {
                return this.BadRequest("Invalid Id - invalid guid format");
            }

            User user = this.Data.Users.Find(id);
            if (user == null)
            {
                return this.BadRequest("Invalid Id - user not found");
            }

            return this.Ok(user.ReceivedMessages.Union(user.SentMessages));
        }*/
        [HttpGet]
        public IHttpActionResult GetMessages()
        {            
            return this.Ok(this.Data.Messages.All());
        }
        /*
        [HttpPost]
        public IHttpActionResult UploadFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var file = HttpContext.Current.Request.Files[0];
                var fileInputStream = file.InputStream;
                byte[] fileAsArray = new byte[file.ContentLength];

                fileInputStream.Read(fileAsArray, 0, file.ContentLength);

                string fileUrl = DropboxUploader.Instance.UploadFileToDropbox(fileAsArray, file.FileName);
                
            }

            return this.Ok();
        }

         */
        [HttpPost]
        public IHttpActionResult PostMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                message.PostOn = DateTime.Now;
                //message.UserId= this.Data.Users.All().Single(x => x.Email == message.User.Email).Id;
                message.UserId = this.UserProvider.GetUserId();
                
                // TODO file attachmentss
                this.Data.Messages.Add(message);
                this.Data.SaveChanges();
            }

            var notification = PubNubNotificationManager.Instance;
            notification.PublishMessage("global", "new message");
            return this.Ok();
        }

        /*
        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            var files = httpRequest.Files;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    docfiles.Add(filePath);
                }

                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return result;
        }
         */
    }
}