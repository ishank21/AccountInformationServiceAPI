using AccountInformationService.Application.Interfaces;
using AccountInformationService.Core.Interfaces;

namespace AccountInformationService.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthentication _authentication;
        public AuthenticationService(IAuthentication authentication) => 
            _authentication = authentication;

        public async Task<bool> IsAuthenticated(bool IsClientRequest, string id) =>
            await _authentication.IsAuthenticated(IsClientRequest, id);
    }
}
