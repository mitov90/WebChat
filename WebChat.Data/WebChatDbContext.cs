﻿namespace WebChat.Data
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

        public IDbSet<File> Files { get; set; }

        public IDbSet<Interest> Interests { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<ChatRoom> ChatRooms { get; set; }

        public static WebChatDbContext Create()
        {
            return new WebChatDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}