using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class MessageDetail : IViewModel
    {
        [Required]
        public string FromUserID { get; set; }

        public string ToUserID { get; set; }

        [Required]
        public string Message { get; set; }
    }
}