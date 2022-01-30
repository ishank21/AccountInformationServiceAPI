using AccountInformationService.Core.Entities;

namespace AccountInformationService.Core.Interfaces
{
    public interface IAccountDetails
    {
        Task<List<AccountDetails>> GetClientAccountDetails(string aplId);
    }
}
