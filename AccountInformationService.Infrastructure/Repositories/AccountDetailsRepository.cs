using AccountInformationService.Core.Entities;
using AccountInformationService.Core.Interfaces;
using AccountInformationService.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AccountInformationService.Infrastructure.Repositories
{
    public class AccountDetailsRepository : IAccountDetails
    {
        private readonly AccountServiceContext _accountServiceContext;
        public AccountDetailsRepository(AccountServiceContext accountServiceContext) => 
            _accountServiceContext = accountServiceContext;

        public async Task<List<AccountDetails>> GetClientAccountDetails(string aplId) =>
            await _accountServiceContext.ClientAccount_Detail.FromSqlRaw("exec SP_GetClientAccount_DetailsByAplID @AplID", new SqlParameter("@AplID",
                aplId)).ToListAsync();

    }
}
