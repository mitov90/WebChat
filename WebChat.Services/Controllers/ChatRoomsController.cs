//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Cors;
//using System.Web.Http.Description;
//using WebChat.Data;
//using WebChat.Models;
//using WebChat.Services.Helpers;

//namespace WebChat.Services.Controllers
//{
//    [EnableCors("*", "*", "*")]
//    public class ChatRoomsController : BaseApiController
//    {
//        private WebChatDbContext db = new WebChatDbContext();

//        public ChatRoomsController(IUserIdProvider userProvider, IWebChatData data)
//            : base(userProvider, data)
//        {
//        }

//        [HttpPost]
//        public IHttpActionResult CreateChatRoom(string otherUserId)
//        {
//            var otherParticipantExists = Data.Users.All().Any(x => x.Id == otherUserId);
//            if (otherParticipantExists)
//            {
//                var currentUser = UserProvider.GetUserId();
//                var newChatRoom = new ChatRoom()
//                {
                    
//                };
//                Data.ChatRooms.Add(newChatRoom);
//            }

//            return this.NotFound();
//        }

//        // GET: api/ChatRooms
//        public IQueryable<ChatRoom> GetChatRooms()
//        {
//            return db.ChatRooms;
//        }

//        // GET: api/ChatRooms/5
//        [ResponseType(typeof(ChatRoom))]
//        public IHttpActionResult GetChatRoom(Guid id)
//        {
//            ChatRoom chatRoom = db.ChatRooms.Find(id);
//            if (chatRoom == null)
//            {
//                return NotFound();
//            }

//            return Ok(chatRoom);
//        }

//        // PUT: api/ChatRooms/5
//        [ResponseType(typeof(void))]
//        public IHttpActionResult PutChatRoom(Guid id, ChatRoom chatRoom)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != chatRoom.ChatRoomId)
//            {
//                return BadRequest();
//            }

//            db.Entry(chatRoom).State = EntityState.Modified;

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ChatRoomExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/ChatRooms
//        [ResponseType(typeof(ChatRoom))]
//        public IHttpActionResult PostChatRoom(ChatRoom chatRoom)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.ChatRooms.Add(chatRoom);

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateException)
//            {
//                if (ChatRoomExists(chatRoom.ChatRoomId))
//                {
//                    return Conflict();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtRoute("DefaultApi", new { id = chatRoom.ChatRoomId }, chatRoom);
//        }

//        // DELETE: api/ChatRooms/5
//        [ResponseType(typeof(ChatRoom))]
//        public IHttpActionResult DeleteChatRoom(Guid id)
//        {
//            ChatRoom chatRoom = db.ChatRooms.Find(id);
//            if (chatRoom == null)
//            {
//                return NotFound();
//            }

//            db.ChatRooms.Remove(chatRoom);
//            db.SaveChanges();

//            return Ok(chatRoom);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool ChatRoomExists(Guid id)
//        {
//            return db.ChatRooms.Count(e => e.ChatRoomId == id) > 0;
//        }
//    }
//}