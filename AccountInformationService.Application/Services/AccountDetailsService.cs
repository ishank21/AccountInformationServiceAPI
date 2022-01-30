using AccountInformationService.Application.Interfaces;
using AccountInformationService.Application.ViewModels;
using AccountInformationService.Core.Interfaces;
using AutoMapper;

namespace AccountInformationService.Application.Services
{
    public class AccountDetailsService : IAccountDetailsService
    {
        private readonly IAccountDetails _accountDetails;
        private readonly IMapper _mapper;
        public AccountDetailsService(IAccountDetails accountDetails, IMapper mapper)
        {
            _accountDetails = accountDetails;
            _mapper = mapper;
        }
        public async Task<List<AccountDetailsViewModel>> GetClientAccountDetails(string aplId)
        {
            var clientAccountDetails = await _accountDetails.GetClientAccountDetails(aplId);
            return _mapper.Map<List<AccountDetailsViewModel>>(clientAccountDetails);
        }
    }
}
