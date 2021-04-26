using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityProject
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }   

        public DateTime DateofBirth { get; set; }
        
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

    }
}
