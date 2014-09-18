namespace WebChat.NotificationManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PubNubMessaging.Core;

    public class PubNubNotificationManager : INotificationManager
    {
        private const string NotificationSubscribeKey = "sub-c-34433516-3e64-11e4-8c81-02ee2ddab7fe";
        private const string NotificationPublishKey = "pub-c-6576e5b7-0139-4662-a73b-50c3d7339d4d";

        private static INotificationManager instance;
        private Pubnub pubNub;
        private Action<object> success;
        private Action<PubnubClientError> error;

        private PubNubNotificationManager()
        {
            this.pubNub = new Pubnub(NotificationPublishKey, NotificationSubscribeKey);
            this.success = this.NotificationSend;
            this.error = this.ErrorSendingNotification;
        }

        public static INotificationManager Instance
        {
            get { return instance ?? (instance = new PubNubNotificationManager()); }
        }

        public string SubscribeKey
        {
            get
            {
                return NotificationSubscribeKey;
            }
        }

        public string PublishKey
        {
            get
            {
                return NotificationPublishKey;
            }
        }

        public void PublishMessage(string channel, string message)
        {
                this.pubNub.Publish(channel, message, this.success, this.error);
        }

        public void PublishMessage(IEnumerable<string> channels, string message)
        {
            foreach(var channel in channels)
            {
                this.pubNub.Publish(channel, message, this.success, this.error);
            }
        }

        private void NotificationSend(object body)
        {
            // Log succesful notification
        }

        private void ErrorSendingNotification(PubnubClientError error)
        {
            // Log error
        }
    }
}
