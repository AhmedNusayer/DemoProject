using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityProject
{
    public class ApplicationUser: IdentityUser, IEntity
    {
        public ApplicationUser()
        {
            Educations = new List<Education>();
            Experiences = new List<Experience>();
            Skills = new List<Skill>();
            Interests = new List<Interest>();
            Projects = new List<Project>();
            Contributions = new List<Contribution>();
        }
        public string Name { get; set; }   

        public DateTime? DateofBirth { get; set; }
        
        public string Address { get; set; }
        public string Intro { get; set; }
        
        public virtual List<Education> Educations { get; set; }
        public virtual List<Experience> Experiences { get; set; }

        public virtual List<Skill> Skills { get; set; }
        public string Knowledge { get; set; }
        public virtual List<Interest> Interests { get; set; }
        public virtual List<Project> Projects { get; set; }
        public string Hobby { get; set; }
        public virtual List<Contribution> Contributions { get; set; }
        public string Github { get; set; }
        public string Website { get; set; }
        public string Linkedin { get; set; }
        public string Gender { get; set; }
        public string Template { get; set; }

        public string BloodGroup { get; set; }
        public string Profession { get; set; }
        public string Nationality { get; set; }
    }
}
