using fin_back.Data.Entities;
using fin_back.Models.Identity;
using fin_back.Models.Indicators;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace fin_back.Data
{
    public sealed class DataContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(b =>
            {
                b.Property(u => u.Id).HasColumnType("varchar(36)");
            });

            builder.Entity<IdentityUserLogin<Guid>>(b =>
            {
                b.Property(u => u.ProviderKey).HasColumnType("longtext").HasMaxLength(1024);
                b.HasKey(u => new { u.LoginProvider, u.UserId });
            });

            builder.Entity<IdentityRole<Guid>>(b =>
            {
                b.Property(u => u.Id).HasColumnType("varchar(36)");
            });

            builder.Entity<IdentityRole<Guid>>().HasData
            (
                new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Member", NormalizedName = "MEMBER" }, 
                new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
            );

            /*builder.Entity<OrganizationIndicators>(b =>
            {
                b.OwnsOne<LiquidityIndicators>(u => u.LiquidityIndicators, builder => { builder.ToJson(); });
                b.OwnsOne<FinancialIndicators>(u => u.FinancialIndicators, builder => { builder.ToJson(); });
                b.OwnsOne<ProfitabilityIndicators>(u => u.ProfitabilityIndicators, builder => { builder.ToJson(); });
            });*/
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Organization> Organization { get; set; } = null!;
        public DbSet<OrganizationIndicators> OrganizationIndicators { get; set; } = null!;
        public DbSet<LiquidityIndicators> LiquidityIndicators { get; set; } = null!;
        public DbSet<ProfitabilityIndicators> ProfitabilityIndicators { get; set; } = null!;
        public DbSet<FinancialIndicators> FinancialIndicators { get; set; } = null!;
    }
}
