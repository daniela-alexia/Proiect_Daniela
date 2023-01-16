using Microsoft.EntityFrameworkCore;
using Proiect_Daniela.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Proiect_Daniela.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Proiect_Daniela.Data
{
    public class DanielaDbContext : IdentityDbContext<Proiect_Daniela.Areas.Identity.Data.ApplicationUser>
    {
        public DanielaDbContext(DbContextOptions<DanielaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }

        // utilizat de migrari ca sa construiasca un nou tabel
        // in baza de date in caz ca nu exista
        public DbSet <Angajat> Angajati { get; set; }
    }


public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    void IEntityTypeConfiguration<ApplicationUser>.Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}
}
