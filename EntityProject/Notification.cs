using System;
using System.ComponentModel.DataAnnotations;

namespace EntityProject
{
    public class Notification : IEntity
    {
        [Key]
        public Guid GUID { get; set; }

        public string Details { get; set; }

        public virtual ApplicationUser userfrom { get; set; }

        public virtual JobPost post { get; set; }

        public virtual ApplicationUser userto { get; set; }

    }
}