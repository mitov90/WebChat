using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebChat.Data;
using WebChat.Models;

namespace WebChat.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            WebChatData data = new WebChatData(new WebChatDbContext());
            var files = data.Files.All().ToList();
            var a = 1;
        }
    }
}
