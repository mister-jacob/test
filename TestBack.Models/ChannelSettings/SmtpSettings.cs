using System;
using System.Collections.Generic;
using System.Text;

namespace TestBack.Models.ChannelSettings
{
    public class SmtpSettings
    {
        public string FromUser { get; set; }

        public string FromEmail { get; set; }

        public string ToEmail { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string Password { get; set; }
    }
}
