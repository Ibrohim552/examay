using exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exam.EntitiesConfiguration
{
    public class EmployeesConfig : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(20).IsRequired();
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.HireDate).IsRequired();
            builder.Property(x => x.Position).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Salary).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DepartmentId).IsRequired();
            builder.Property(x => x.ManagerId).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.Address).HasMaxLength(255).IsRequired();
            builder.Property(x => x.City).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(100).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}