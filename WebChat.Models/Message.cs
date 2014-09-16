namespace WebChat.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message
    {
        public int Id { get; set; }

        public DateTime PostOn { get; set; }

        public string Body { get; set; }

        public int? FileId { get; set; }

        [ForeignKey("User")]
        public Guid? ReceiverGuid { get; set; }

        public Guid UserId { get; set; }
    }
}