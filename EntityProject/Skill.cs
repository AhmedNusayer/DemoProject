using System;
using System.ComponentModel.DataAnnotations;

namespace EntityProject
{
    public class Skill:IEntity
    {
        [Key]
        public Guid GUID { get; set; }
        public string SkillName { get; set; }
        public int Level { get; set; }
    }
}