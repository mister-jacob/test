using System;
using System.Collections.Generic;
using System.Text;

namespace TestBack.Models.ChannelSettings
{
    public class TelegramSettings
    {
        public int ApiId { get; set; }

        public string PhoneNumber { get; set; }

        public string ApiHash { get; set; }

        public string Channel { get; set; }
    }
}
