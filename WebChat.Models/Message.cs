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

        [ForeignKey("Sender")]
        public string SenderId { get; set; }

        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Receiver { get; set; }
    }
}