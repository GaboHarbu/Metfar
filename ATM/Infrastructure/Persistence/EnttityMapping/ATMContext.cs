using Microsoft.EntityFrameworkCore;

namespace Db.Persistence.EnttityMapping
{
    public class ATMContext : DbContext
    {
        public ATMContext(DbContextOptions<ATMContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Lock> Locks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}