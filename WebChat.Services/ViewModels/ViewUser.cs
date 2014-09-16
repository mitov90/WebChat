namespace WebChat.Services.ViewModels
{
    using System;
    using System.Collections.Generic;

    using WebChat.Models;
    using WebChat.Models.Enums;

    public class ViewUser
    {
        public static Func<User, ViewUser> GetData
        {
            get
            {
                return
                    u =>
                    new ViewUser
                        {
                            Id = u.Id, 
                            ProfileImage = u.ProfileImage, 
                            Location = u.Location, 
                            Name = u.Name, 
                            Sex = u.Sex, 
                            Age = u.Age, 
                            Interests = u.Interests
                        };
            }
        }

        public string Id { get; set; }

        public byte[] ProfileImage { get; set; }

        public string Location { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        public byte Age { get; set; }

        public ICollection<Interest> Interests { get; set; }
    }
}