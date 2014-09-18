namespace WebChat.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        public DateTime PostOn { get; set; }

        public string Body { get; set; }

        public int? FileId { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }
    }
}