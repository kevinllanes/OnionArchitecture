using System.ComponentModel.DataAnnotations;

namespace OnionArchitecture.ViewModels.Identity
{
    public class ForgotPasswordViewModel {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}