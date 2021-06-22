using System;
using System.ComponentModel.DataAnnotations;

namespace EntityProject
{
    public class Interest :IEntity
    {
        [Key]
        public Guid GUID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}