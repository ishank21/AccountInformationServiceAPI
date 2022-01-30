using AccountInformationService.Application.ViewModels;

namespace AccountInformationService.Application.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDetailsViewmodel>> GetClientDetails(string aplId);
    }
}
