using AccountInformationService.API.Entities;
using AccountInformationService.Infrastructure.Common.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using AuthenticationService = AccountInformationService.Application.Interfaces;

namespace AccountInformationService.API.Middleware
{
    public class CustomTokenAuthHandler : AuthenticationHandler<CustomTokenAuthOptions>
    {
        private readonly AuthenticationService.IAuthenticationService _authenticationService;
        public CustomTokenAuthHandler(IOptionsMonitor<CustomTokenAuthOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder urlEncoder,
            ISystemClock systemClock,
            AuthenticationService.IAuthenticationService authenticationService) :
            base(options, loggerFactory, urlEncoder, systemClock) => _authenticationService = authenticationService;

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(Options.TokenHeaderName))
                return Task.FromResult(AuthenticateResult.Fail($"Missing Header : {Options.TokenHeaderName}"));

            var headerValue = Request.Headers[Options.TokenHeaderName];

            int counter = 1;

            if (headerValue.ToString().Split(" ").Length == 1) counter = 0;

            var token = headerValue.ToString().Split(" ")[counter].Trim();

            if (!token.IsBase64String())
                return Task.FromResult(AuthenticateResult.Fail($"Invalid Header value : {token}"));

            var json = Encoding.UTF8.GetString(Convert.FromBase64String(token));

            var result = JsonConvert.DeserializeObject<UserDetails>(json);

            var isClientRequest = Convert.ToString(Request.RouteValues["controller"]) == "Clients";


            if (string.IsNullOrEmpty(result.AplId) || !_authenticationService.IsAuthenticated(isClientRequest, result.AplId).Result)
                return Task.FromResult(AuthenticateResult.Fail($"You are not Authorized to call this endpoint"));

            var claims = new[]
            {
                new Claim(ClaimTypes.Name , result.UserName)
            };

            var id = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(id);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
