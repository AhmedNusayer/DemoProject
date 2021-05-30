using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityProject
{
    public class Message: IEntity
    {
        [Key]
        public Guid GUID { get; set; }

        public virtual ApplicationUser UserFrom { get; set; }

        public virtual ApplicationUser UserTo { get; set; }

        public DateTime? Time { get; set; }

        public string MessageDetails { get; set; }
    }
}
