using MovieDB.Tables;
using System.Data.Entity;

namespace MovieDB.Model
{
    class AccountContext: DbContext
    {
        public AccountContext() : base("DbConnection"){}
        public DbSet<Account> Accounts { get; set; }
    }
}