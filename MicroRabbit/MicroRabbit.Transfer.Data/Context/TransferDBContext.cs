using MicroRabbit.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System.Linq;

namespace MicroRabbit.Transfer.Data.Context
{
    public class TransferDBContext : DbContext
    {
        private DbContextOptions<TransferDBContext> _options { get; set; }
        private string DefaultConnection { get; set; }

        public TransferDBContext(DbContextOptions<TransferDBContext> options) : base(options)
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
            modelBuilder.Entity<TransferLog>(
                b =>
                {
                    b.HasKey("Id");
                    b.Property(e => e.FromAccount).IsRequired();
                    b.Property(e => e.ToAccount).IsRequired();
                    b.Property(e => e.TransferAmount).IsRequired();
                });
        }

        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}
