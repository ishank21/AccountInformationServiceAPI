using AccountInformationService.Core.Entities;

namespace AccountInformationService.Core.Interfaces
{
    public interface IClient
    {
        Task<List<ClientDetails>> GetClientDetails(string aplId);
    }
}
