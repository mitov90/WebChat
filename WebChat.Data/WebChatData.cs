namespace WebChat.Data
{
    using System;
    using System.Collections.Generic;

    using WebChat.Data.Repositories;
    using WebChat.Models;

    public class WebChatData
    {
        private readonly WebChatDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public WebChatData(WebChatDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<File> Files
        {
            get
            {
                return this.GetRepository<File>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Message> Messages
        {
            get
            {
                return this.GetRepository<Message>();
            }
        }

        public IRepository<Interest> Interests
        {
            get
            {
                return this.GetRepository<Interest>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            Type typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                object newRepository = Activator.CreateInstance(typeof(Repository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}