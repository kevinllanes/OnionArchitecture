using System.Collections.Generic;
using OnionArchitecture.Core.DomainModels.Identity;

namespace OnionArchitecture.ViewModels.Identity
{
    public class ManageLoginsViewModel {
        public IList<ApplicationUserLoginInfo> CurrentLogins { get; set; }
        public IList<ApplicationAuthenticationDescription> OtherLogins { get; set; }
    }
}