namespace AccountInformationService.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> IsAuthenticated(bool IsClientRequest, string id);
    }
}
