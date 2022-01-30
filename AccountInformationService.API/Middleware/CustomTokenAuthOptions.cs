using Microsoft.AspNetCore.Authentication;

namespace AccountInformationService.API.Middleware
{
    public class CustomTokenAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "CustomTokenAuthScheme";
        public string TokenHeaderName { get; set; } = "Authorization";
    }
}
