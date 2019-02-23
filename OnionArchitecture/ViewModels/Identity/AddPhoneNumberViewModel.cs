using System.ComponentModel.DataAnnotations;

namespace OnionArchitecture.ViewModels.Identity
{
    public class AddPhoneNumberViewModel {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}