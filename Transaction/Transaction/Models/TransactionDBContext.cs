using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Transaction.Models
{
    public class TransactionDBContext : DbContext
    {
        public TransactionDBContext(DbContextOptions<TransactionDBContext> options) : base(options)
        {
        }

        public DbSet<TransactionModel> tr_bpkb { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<TransactionModel>()
        //      .HasNoKey();
        //}
    }
}
