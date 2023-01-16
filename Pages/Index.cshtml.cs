using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Daniela.Data;
using Proiect_Daniela.Models.Domain;
using Proiect_Daniela.Models.ViewModels;

namespace Proiect_Daniela.Pages
{
    public class IndexModel : PageModel
    {


        private readonly DanielaDbContext dbContext;

        public IndexModel(DanielaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
     

        public List<Angajat> Angajati { get; set; }

        public void OnGet()
        {
            Angajati = new List<Angajat>();
        }

        public async Task OnPostAsync()
        {
            var searchString = Request.Form["searchString"];

            Angajati = await dbContext.Angajati.Where(x => x.Name.Contains(searchString)).ToListAsync();
        }
    }
}
