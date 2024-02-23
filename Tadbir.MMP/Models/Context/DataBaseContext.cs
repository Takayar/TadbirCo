using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Tadbir.MMP.Models.Entities;
using Tadbir.MMP.Seeds;

namespace Tadbir.MMP.Models.Context
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        public DbSet<ReqDetails> ReqDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasQueryFilter(p=>!p.IsRemoved);
            DataBaseContextSeed.TypeSeed(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }

    }
}
