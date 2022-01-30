using AccountInformationService.Core.Interfaces;
using AccountInformationService.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AccountInformationService.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthentication
    {
        private readonly AccountServiceContext _accountServiceContext;
        public AuthenticationRepository(AccountServiceContext accountServiceContext) => 
            _accountServiceContext = accountServiceContext;

        public async Task<bool> IsAuthenticated(bool IsClientRequest, string id)
        {
            dynamic clientDetails = string.Empty;

            if (IsClientRequest)
                clientDetails = await _accountServiceContext.Client_Detail
                                                            .FirstOrDefaultAsync(x => x.UserID.Equals(id));
            else
                clientDetails = await _accountServiceContext.ClientAccount_Detail
                                                            .FirstOrDefaultAsync(x => x.UserID.Equals(id));

            return clientDetails != null;
        }
    }
}
