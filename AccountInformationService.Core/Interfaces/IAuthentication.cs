namespace AccountInformationService.Core.Interfaces
{
    public interface IAuthentication
    {
        Task<bool> IsAuthenticated(bool IsClientRequest, string id);
    }
}
