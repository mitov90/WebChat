namespace WebChat.Models
{
    using System.ComponentModel.DataAnnotations;

    using WebChat.Models.Enums;

    internal class File
    {
        public int Id { get; set; }

        public FileType Type { get; set; }

        public string Filename { get; set; }

        [Required]
        public string Link { get; set; }
    }
}