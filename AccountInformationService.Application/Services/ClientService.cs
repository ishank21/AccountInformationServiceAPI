using AccountInformationService.Application.Interfaces;
using AccountInformationService.Application.ViewModels;
using AccountInformationService.Core.Interfaces;
using AutoMapper;

namespace AccountInformationService.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClient _client;
        private readonly IMapper _mapper;
        public ClientService(IClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }
        public async Task<List<ClientDetailsViewmodel>> GetClientDetails(string aplId)
        {
            var clientDetails = await _client.GetClientDetails(aplId);
            return _mapper.Map<List<ClientDetailsViewmodel>>(clientDetails);
        }
    }
}
