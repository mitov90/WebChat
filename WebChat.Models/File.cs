namespace WebChat.Models
{
    using System.ComponentModel.DataAnnotations;

    using WebChat.Models.Enums;

    public class File
    {
        public int Id { get; set; }

        public FileType Type { get; set; }

        public string Filename { get; set; }

        [Required]
        public string Link { get; set; }

        public int MessageId { get; set; }

        public virtual Message Message { get; set; }
    }
}