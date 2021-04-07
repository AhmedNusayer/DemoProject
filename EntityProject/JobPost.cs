using System;
using System.ComponentModel.DataAnnotations;

namespace EntityProject
{
    public class JobPost : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string JobTitle { get; set; }

        public string JobType { get; set; }

        public string JobLocation { get; set; }

        public int NoOfPosts { get; set; }

        public string JobDescription { get; set; }

        public int SalaryRangeStart { get; set; }

        public int SalaryRangeEnd { get; set; }

        public DateTime TimeofPost { get; set; }

        public virtual ApplicationUser PostAuthor { get; set; }

        public virtual Company CompanyInfo { get; set; }

    }
}
