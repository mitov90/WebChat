namespace WebChat.Data
{
    using WebChat.Data.Repositories;
    using WebChat.Models;

    public interface IWebChatData
    {
        IRepository<User> Users { get; }

        IRepository<Message> Messages { get; }

        IRepository<File> Files { get; }

        IRepository<Interest> Interests { get; }

        int SaveChanges();
    }
}