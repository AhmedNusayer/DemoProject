using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }   

        public DateTime DateofBirth { get; set; }
        
        public string Address { get; set; }
    }
}
