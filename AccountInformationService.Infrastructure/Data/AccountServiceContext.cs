using AccountInformationService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountInformationService.Infrastructure.Data
{
    public class AccountServiceContext : DbContext
    {
        public AccountServiceContext(DbContextOptions<AccountServiceContext> dbContextOptions):
            base(dbContextOptions)
        { }

        public DbSet<ClientDetails> Client_Detail { get; set; }
        public DbSet<AccountDetails> ClientAccount_Detail { get; set; }
    }
}
