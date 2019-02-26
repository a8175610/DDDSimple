using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DDD.Sample.Domain.Aggregate;

namespace DDD.Sample.Infrastructure.EFMap
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            //主键
            this.HasKey(t => t.Id);
            //自增ID
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Name).IsRequired();
            this.Property(t => t.Age).IsRequired();
            this.Property(t => t.RowVersion).IsRowVersion();

            this.ToTable("Students");

        }
    }
}
