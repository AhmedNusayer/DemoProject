using System;
using System.ComponentModel.DataAnnotations;

namespace EntityProject
{
    public class Experience:IEntity
    {
        [Key]
        public Guid GUID { get; set; }
        public string Title { get; set; }
        public string EmploymentType { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

    }
}