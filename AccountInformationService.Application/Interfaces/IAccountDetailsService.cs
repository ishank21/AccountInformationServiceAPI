using AccountInformationService.Application.ViewModels;

namespace AccountInformationService.Application.Interfaces
{
    public interface IAccountDetailsService
    {
        Task<List<AccountDetailsViewModel>> GetClientAccountDetails(string aplId);
    }
}
