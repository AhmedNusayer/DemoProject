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
        public ApplicationUser UserDetails { get; set; }

    }
}
