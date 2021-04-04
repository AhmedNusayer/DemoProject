using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class RegisterCompanyModel : IViewModel
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyLocation { get; set; }

        [Required]
        public string CompanyAddress { get; set; }

        [Required]
        public string CompanyType { get; set; }

        [Required]
        public string CompanyEmail { get; set; }

        [Required]
        public string VerificationCode { get; set; }
    }
}
