using exam.Entities;

namespace exam.DateContext;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext:DbContext
{
    public DbSet<Employees> Employee { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}