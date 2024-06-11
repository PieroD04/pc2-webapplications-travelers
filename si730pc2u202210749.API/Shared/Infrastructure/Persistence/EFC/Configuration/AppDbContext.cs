using si730pc2u202210749.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730pc2u202210749.API.Subscriptions.Domain.Model.Aggregates;

namespace si730pc2u202210749.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }
    // Sirve para usarlo en el Service y poder crear queries como findByTripId en vez de Id
    public DbSet<Plan> Plans { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Subscriptions Context
        
        //Plan Table
        // Adds the primary key
        builder.Entity<Plan>().HasKey(p => p.Id);
        // Adds the primary key with autoincrement
        builder.Entity<Plan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        // Adds value objects as columns
        builder.Entity<Plan>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("id");
                n.Property(a => a.Name).HasColumnName("Name");
            });
        
        builder.Entity<Plan>().OwnsOne(p => p.MaxUsers,
            m =>
            {
                m.WithOwner().HasForeignKey("id");
                m.Property(u => u.MaxUsers).HasColumnName("MaxUsers");
            });
        
        builder.Entity<Plan>().OwnsOne(p => p.IsDefault,
            d =>
            {
                d.WithOwner().HasForeignKey("id");
                d.Property(i => i.IsDefault).HasColumnName("IsDefault");
            });
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}