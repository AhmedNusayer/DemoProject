using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityProject
{
    public class Employer: IEntity
    {

        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Company CompanyInfo { get; set; }

    }
}
