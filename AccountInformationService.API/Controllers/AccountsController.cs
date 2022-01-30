using AccountInformationService.API.Entities;
using AccountInformationService.API.Middleware;
using AccountInformationService.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AccountInformationService.API.Controllers
{
    [Authorize(AuthenticationSchemes = CustomTokenAuthOptions.DefaultScheme)]
    [ApiController]
    [Route("api/accountinfo/v{version:apiversion}/accounts")]
    public class AccountsController : Controller
    {
        private readonly IAccountDetailsService _accountDetailsService;
        public AccountsController(IAccountDetailsService accountDetailsService) => 
            _accountDetailsService = accountDetailsService;

        /// <summary>
        /// Get client account details by aplid present in headers
        /// </summary>
        /// <returns>AccountDetailsViewModel</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClientDetails()
        {
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(Request.Headers[new CustomTokenAuthOptions().TokenHeaderName]));
            var aplId = JsonConvert.DeserializeObject<UserDetails>(json).AplId;
            var clientAccountDetails = await _accountDetailsService.GetClientAccountDetails(aplId);
            return Ok(clientAccountDetails);
        }
    }
}
