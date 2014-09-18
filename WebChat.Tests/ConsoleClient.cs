namespace WebChat.Tests
{
    using System;
    using System.Linq;

    using WebChat.Data;
    using WebChat.Models;

    internal class ConsoleClient
    {
        private static void Main()
        {
            //WebChatData data = new WebChatData(new WebChatDbContext());

            //User newPesho = new User
            //                    {
            //                        Name = "not1Null", 
            //                        UserName = "pe2s2hkat1a", 
            //                        Email = "abv3@1abv2.bg", 
            //                        Age = 10, 
            //                        Location = "Plovdiv"
            //                    };
            //data.Users.Add(newPesho);

            //Message newMessage = new Message
            //                         {
            //                             Body = "Test Message", 
            //                             Sender = newPesho, 
            //                             Receiver = newPesho, 
            //                             PostOn = DateTime.Now
            //                         };

            //data.Messages.Add(newMessage);
            //data.SaveChanges();

            //foreach (var message in data.Messages.All().ToList())
            //{
            //    Console.WriteLine(message.Body);
            //}
        }
    }
}