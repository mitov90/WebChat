namespace WebChat.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using WebChat.Data.Migrations;
    using WebChat.Models;

    public class WebChatDbContext : IdentityDbContext<User>
    {
        public WebChatDbContext()
            : base("WebChatDb", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WebChatDbContext, Configuration>());
        }

        public static WebChatDbContext Create()
        {
            return new WebChatDbContext();
        }

        public IDbSet<File> Files { get; set; }

        public IDbSet<Interest> Interests { get; set; }

        public IDbSet<Message> Messages { get; set; }

        //public IDbSet<User> Users { get; set; }
    }
}