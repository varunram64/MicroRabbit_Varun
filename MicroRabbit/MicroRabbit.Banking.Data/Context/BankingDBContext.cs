using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Linq;

namespace MicroRabbit.Banking.Data.Context
{
    public class BankingDBContext : DbContext
    {
        private DbContextOptions<BankingDBContext> _options { get; set; }
        private string DefaultConnection { get; set; }

        public BankingDBContext(DbContextOptions<BankingDBContext> options) : base(options)
        {
            _options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (_options != null && !optionsBuilder.IsConfigured)
            {
                DefaultConnection = ((SqlServerOptionsExtension)(_options.Extensions.FirstOrDefault())).ConnectionString;
                optionsBuilder.UseSqlServer(DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(
                b =>
                {
                    b.HasKey("Id");
                    b.Property(e => e.AccountType).IsRequired();
                    b.Property(e => e.AccountBalance).IsRequired();
                });
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
