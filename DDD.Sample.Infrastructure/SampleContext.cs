using System.Data.Entity;
using DDD.Sample.Domain.Aggregate;
using DDD.Sample.Infrastructure.EFMap;
using DDD.Sample.Infrastructure.Interface;

namespace DDD.Sample.Infrastructure
{
    public class SampleContext : DbContext, IDbContext
    {
        public SampleContext() : base("name=SampleContext")
        {
            
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

