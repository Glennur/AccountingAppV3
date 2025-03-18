using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAppV3.Models
{
    class BokforingContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<HouseHold> HouseHolds { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<YearStatus> yearStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BokforingssystemV3;Trusted_Connection=True; TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definiera en-till-många relationer mellan Account och Transaction
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.DebitAccount)
                .WithMany(a => a.DebitTransactions)
                .HasForeignKey(t => t.DebitAccountId)
                .OnDelete(DeleteBehavior.Restrict); // Eller SetNull beroende på krav

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.CreditAccount)
                .WithMany(a => a.CreditTransactions)
                .HasForeignKey(t => t.CreditAccountId)
                .OnDelete(DeleteBehavior.Restrict); // Eller SetNull beroende på krav

            modelBuilder.Entity<YearStatus>()
                .HasKey(y => y.Year);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.YearStatus)
                .WithMany(y => y.Transactions)
                .HasForeignKey(t => t.Year) // Använd Year som främmande nyckel
                .OnDelete(DeleteBehavior.Restrict); // Eller SetNull beroende på krav
        }
    }
}
