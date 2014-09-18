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

        [MinLength(1)]
        [Required]
        public string Body { get; set; }

        public string UserId { get; set; }

        public int? FileId { get; set; }

        public int? ChatRoomId { get; set; }

        public virtual User User { get; set; }

        public virtual File File { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }
    }
}