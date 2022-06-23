using CryptoTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CryptoUser> CryptoUsers { get; set; }
        public DbSet<CryptoUserTransaction> CryptoUserTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CryptoUserTransaction>()
                .HasKey(cut => new { cut.userID, cut.transactionID });
            modelBuilder.Entity<CryptoUserTransaction>()
                .HasOne(c => c.CryptoUser)
                .WithMany(c => c.UserTransactions)
                .HasForeignKey(fk => fk.userID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CryptoUserTransaction>()
                .HasOne(c => c.Transactions)
                .WithMany(c => c.UserTransactions)
                .HasForeignKey(fk => fk.transactionID)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
