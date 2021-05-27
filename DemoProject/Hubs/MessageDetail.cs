using System;

namespace WebProject.Hubs
{
    public class MessageDetail
    {
        public string FromUserID { get; set; }

        public string FromUserName { get; set; }

        public string ToUserID { get; set; }

        public string ToUserName { get; set; }

        public DateTime Time { get; set; }

        public string Message { get; set; }
    }
}