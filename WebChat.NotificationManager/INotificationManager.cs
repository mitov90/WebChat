namespace WebChat.NotificationManager
{
    using System.Collections.Generic;


    public interface INotificationManager
    {
        string SubscribeKey { get; }

        string PublishKey{ get; }

        void PublishMessage(string channel, string message);

        void PublishMessage(IEnumerable<string> channels, string message);
        
    }
}
