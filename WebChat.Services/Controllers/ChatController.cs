namespace WebChat.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using WebChat.Data;
    using WebChat.Models;
    using WebChat.Services.Helpers;
    using WebChat.Services.ViewModels;

    [Authorize]
    [EnableCors("*", "*", "*")]
    public class ChatController : BaseApiController
    {
        // GET api/values
        public ChatController(IUserIdProvider userProvider, IWebChatData data)
            : base(userProvider, data)
        {
        }

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
        public IHttpActionResult GeMessages(string id)
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
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}