using ATM.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ATM.Infrastructure.Persistence.EntityMapping
{
    public class ATMContext : DbContext
    {
        public ATMContext(DbContextOptions<ATMContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var accounts = new List<Account>
            {
                new Account(1,12345678, "Bruce Wayne", 9000.00f, DateTime.Now.AddMonths(-1)),
                new Account(2,98765432, "Indiana Jones", 450.00f, DateTime.Now.AddMonths(-2)),
                new Account(3,11111110, "Darth Vader", 1800.00f, DateTime.Now.AddMonths(-3)),
                new Account(4,22222220, "Jack Sparrow", 675.00f, DateTime.Now.AddMonths(-4)),
                new Account(5,33333333, "John Rambo", 1050.00f, DateTime.Now.AddMonths(-5)),
                new Account(6,44444444, "Peter Parker", 270.00f, DateTime.Now.AddMonths(-6)),
                // Agrega más cuentas aquí si es necesario
            };

            var cards = new List<Card>
            {
                new Card(1,"111222333444", 1234, 1, false, 0),
                new Card(2,"555666777888", 5678, 2, false, 0),
                new Card(3, "999888777666", 9876, 3, false, 0),
                new Card(4, "333222111000", 3210, 4, false, 0),
                new Card(5, "777666555444", 7654, 5, false, 0),
                new Card(6, "222333444555", 2345, 6, false, 0),
            };

            var transactions = new List<Transaction>
            {
                new Transaction(1,1, 1000.00f, 10000.00f, 9000.00f, 1),
                new Transaction(2,2, 50.00f, 500.00f, 450.00f, 1),
                new Transaction(3,3, 200.00f, 2000.00f, 1800.00f, 1),
                new Transaction(4,4, 75.00f, 750.00f, 675.00f, 1),
                new Transaction(5,5, 150.00f, 1200.00f, 1050.00f, 1),
                new Transaction(6,6, 30.00f, 300.00f, 270.00f, 1),
            };

            modelBuilder.Entity<Account>().HasData(accounts);
            modelBuilder.Entity<Card>().HasData(cards);
            modelBuilder.Entity<Transaction>().HasData(transactions);

            base.OnModelCreating(modelBuilder);
        }
    }
}
