using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityProject
{
    public class Employer: IEntity
    {

        [Key]
        [ForeignKey("Id")]
        public virtual ApplicationUser User { get; set; }

        public virtual Company CompanyInfo { get; set; }

    }
}
