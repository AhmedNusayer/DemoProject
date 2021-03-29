using System.ComponentModel.DataAnnotations;

namespace EntityProject
{
    public class Company: IEntity
    {
        [Key]
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string CompanyLocation { get; set; }

        public string CompanyAddress { get; set; }

        public string CompanyType { get; set; }

        public string CompanyEmail { get; set; }

    }
}
