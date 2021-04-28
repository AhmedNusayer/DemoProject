using EntityProject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class UpdateModel : IViewModel
    {
        //[Required]
        public ApplicationUser UserDetails { get; set; }

        /*public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        [DataType(DataType.Text)]
        public DateTime DateofBirth { get; set; }
*/

        //[Required]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        /*public string Intro { get; set; }
        public string Knowledge { get; set; }
        public string Hobby { get; set; }
        public string Website { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }
        public virtual List<Education> Educations { get; set; }*/
    }
}
