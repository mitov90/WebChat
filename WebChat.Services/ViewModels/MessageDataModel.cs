using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Services.ViewModels
{
    public class MessageDataModel
    {
        public DateTime PostOn { get; set; }

        public string Body { get; set; }
    }
}