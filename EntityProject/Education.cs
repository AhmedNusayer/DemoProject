using System;
using System.ComponentModel.DataAnnotations;

namespace EntityProject
{
    public class Education:IEntity
    {
        [Key]
        public Guid GUID { get; set; }
        public string Institution { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Grade { get; set; }
        public string Description { get; set; }
    }
}