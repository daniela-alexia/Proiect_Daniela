using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proiect_Daniela.Models.Domain;

namespace Proiect_Daniela.Data
{
    public class DanielaDbContext : IdentityDbContext<IdentityUser>
    {
    
        public DanielaDbContext(DbContextOptions<DanielaDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        // utilizat de migrari ca sa construiasca un nou tabel
        // in baza de date in caz ca nu exista
        public DbSet <Angajat> Angajati { get; set; }

        // utilizat de migrari ca sa construiasca un nou tabel
        // in baza de date in caz ca nu exista
        public DbSet<Proiect_Daniela.Models.Domain.Departament> Departament { get; set; }
    }
}
