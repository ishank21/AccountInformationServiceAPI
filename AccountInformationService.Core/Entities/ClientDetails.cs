using Microsoft.EntityFrameworkCore;

namespace AccountInformationService.Core.Entities
{
    [Keyless]
    public class ClientDetails
    {
        public string? ClientID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? ClientType { get; set; }
        public string? UserID { get; set; }
    }
}
