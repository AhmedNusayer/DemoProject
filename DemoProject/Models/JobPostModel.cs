using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class JobPostModel : IViewModel
    {
        [Required]
        public string JobTitle { get; set; }

        public string JobType { get; set; }

        [Required]
        public string JobLocation { get; set; }

        [Required]
        public int NoOfPosts { get; set; }

        [Required]
        public string JobDescription { get; set; }

        public int SalaryRangeStart { get; set; }

        public int SalaryRangeEnd { get; set; }
    }
}
