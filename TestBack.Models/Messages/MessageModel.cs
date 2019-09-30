using System;
using System.Collections.Generic;
using System.Text;

namespace TestBack.Models.Messages
{
    public class MessageModel
    {
        public int ProjectId { get; }

        public string Subject { get; }

        public string Body { get; }

        public MessageModel(string subject, string body, int projectId)
        {
            Subject = subject;
            Body = body;
            ProjectId = projectId;
        }
    }
}
