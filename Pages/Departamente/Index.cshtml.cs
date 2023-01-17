using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Daniela.Data;
using Proiect_Daniela.Models.Domain;

namespace Proiect_Daniela.Pages.Departamente
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Daniela.Data.DanielaDbContext _context;

        public IndexModel(Proiect_Daniela.Data.DanielaDbContext context)
        {
            _context = context;
        }

        public IList<Departament> Departament { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Departament != null)
            {
                Departament = await _context.Departament.ToListAsync();
            }
        }
    }
}
