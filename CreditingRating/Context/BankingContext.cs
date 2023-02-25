using CreditingRating.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditingRating.Context
{
    public class BankingContext : DbContext
    {
        public BankingContext() : base()
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<CreditHistory> CreditHistories { get; set; }

        public DbSet<BankClient> BankClients { get; set; }

        public DbSet<Person> Persone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankClient>()
            .HasKey(cb => new { cb.ClientId, cb.BankId });

            modelBuilder.Entity<BankClient>()
                .HasOne(cb => cb.Client)
                .WithMany(c => c.ClientBanks)
                .HasForeignKey(cb => cb.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BankClient>()
                .HasOne(cb => cb.Bank)
                .WithMany(b => b.BankClients)
                .HasForeignKey(cb => cb.BankId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CreditHistory>()
            .Property(c => c.PaymentHistory)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;");
        }
    }
}
