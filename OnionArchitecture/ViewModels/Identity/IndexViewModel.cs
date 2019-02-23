using System.Collections.Generic;
using OnionArchitecture.Core.DomainModels.Identity;

namespace OnionArchitecture.ViewModels.Identity
{
    public class IndexViewModel {
        public bool HasPassword { get; set; }
        public IList<ApplicationUserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }
}