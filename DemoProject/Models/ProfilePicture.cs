using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Models
{
    public class ProfilePicture
    {
        [Key]
        public int PhotoId { get; set; }
        public string ProfilePicturePath { get; set; }
        public virtual ApplicationUser UserProfile { get; set; }
    }
}
