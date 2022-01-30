using AccountInformationService.Core.Entities;
using AccountInformationService.Core.Interfaces;
using AccountInformationService.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AccountInformationService.Infrastructure.Repositories
{
    public class ClientRepository : IClient
    {
        private readonly AccountServiceContext _accountServiceContext;
        public ClientRepository(AccountServiceContext accountServiceContext) => 
            _accountServiceContext = accountServiceContext;
        public async Task<List<ClientDetails>> GetClientDetails(string aplId) =>
            await _accountServiceContext.Client_Detail.FromSqlRaw("exec SP_GetClient_DetailsByAplID @AplID", new SqlParameter("@AplID",
                aplId)).ToListAsync();
    }
}
