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
    [Route("api/accountinfo/v{version:apiversion}/clients")]
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService) => 
            _clientService = clientService;

        /// <summary>
        /// Get client details by aplid present in headers
        /// </summary>
        /// <returns>List of ClientDetailsViewmodel</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClientDetails()
        {
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(Request.Headers[new CustomTokenAuthOptions().TokenHeaderName]));
            var aplId = JsonConvert.DeserializeObject<UserDetails>(json).AplId;
            var clientDetails = await _clientService.GetClientDetails(aplId);
            return Ok(clientDetails);
        }
    }
}
