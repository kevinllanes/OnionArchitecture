using System.Collections.Generic;

namespace OnionArchitecture.ViewModels.Identity
{
    public class ConfigureTwoFactorViewModel {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }

}