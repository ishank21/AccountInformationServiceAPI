using Microsoft.EntityFrameworkCore;

namespace AccountInformationService.Core.Entities
{
    [Keyless]
    public class AccountDetails
    {
        public string AccoundId { get; set; }
        public string CustodianId { get; set; }
        public string CustodianName { get; set; }
        public string RegisteredName { get; set; }
        public string ClientId { get; set; }
        public string UserID { get; set; }
        public string CustodialAccountNumber { get; set; }
        public string MarketValue { get; set; }
        public string ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string IsClosed { get; set; }
    }
}
