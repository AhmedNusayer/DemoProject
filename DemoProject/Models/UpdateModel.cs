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
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        [DataType(DataType.Text)]
        public DateTime DateofBirth { get; set; }

        public IFormFile File { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
