using System.Collections.Generic;
using OnionArchitecture.Core.DomainModels.Identity;

namespace OnionArchitecture.ViewModels.Identity
{
    public class ExternalLoginListViewModel {
        public string ReturnUrl { get; set; }
        public IEnumerable<ApplicationAuthenticationDescription> LoginProviders { get; set; }
    }
}