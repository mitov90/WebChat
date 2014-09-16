namespace WebChat.Models
{
    using System.Collections.Generic;

    public class Interest
    {
        private ICollection<User> users;

        public Interest()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }
    }
}