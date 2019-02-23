using System.ComponentModel.DataAnnotations;

namespace OnionArchitecture.ViewModels.Identity
{
    public class ExternalLoginConfirmationViewModel {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}