using System;
using System.ComponentModel.DataAnnotations;

namespace EntityProject
{
    public class Project:IEntity
    {
        [Key]
        public Guid GUID { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

    }
}