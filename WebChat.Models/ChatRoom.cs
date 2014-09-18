namespace WebChat.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChatRoom
    {
        private ICollection<User> participants;
        private ICollection<Message> messages;

        public ChatRoom()
        {
            this.participants = new HashSet<User>();
            this.messages = new HashSet<Message>();
            this.ChatRoomId = new Guid();
        }

        public Guid ChatRoomId { get; set; }

        public ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }

        public virtual ICollection<User> Participants
        {
            get { return this.participants; }
            set { this.participants = value; }
        }
    }
}
