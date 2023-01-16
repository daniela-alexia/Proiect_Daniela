using Microsoft.EntityFrameworkCore;
using Proiect_Daniela.Models.Domain;

namespace Proiect_Daniela.Data
{
    public class DanielaDbContext : DbContext
    {
        public DanielaDbContext(DbContextOptions options) : base(options)
        {
        }


        // utilizat de migrari ca sa construiasca un nou tabel
        // in baza de date in caz ca nu exista
        public DbSet <Angajat> Angajati { get; set; }
    }
}
