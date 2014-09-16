namespace WebChat.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using WebChat.Models.Enums;

    public class User : IdentityUser
    {
        private ICollection<Interest> interests;

        public User()
        {
            this.interests = new HashSet<Interest>();
        }

        public byte[] ProfileImage { get; set; }

        public string Location { get; set; }

        [DisplayName("Username")]
        public string Name { get; set; }

        public Sex Sex { get; set; }

        public byte Age { get; set; }

        public virtual ICollection<Interest> Interests
        {
            get
            {
                return this.interests;
            }

            set
            {
                this.interests = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<User> manager, 
            string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }
    }
}