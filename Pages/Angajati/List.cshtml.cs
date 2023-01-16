using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Daniela.Data;
using Proiect_Daniela.Models.Domain;

namespace Proiect_Daniela.Pages.Angajati
{
    public class ListModel : PageModel
    {
        private readonly DanielaDbContext dbContext;

        public List<Models.Domain.Angajat> Angajati { get; set; }
        public ListModel(DanielaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            Angajati = dbContext.Angajati.ToList();
        }
    }
}
