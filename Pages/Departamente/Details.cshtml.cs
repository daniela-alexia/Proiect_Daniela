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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Daniela.Data.DanielaDbContext _context;

        public DetailsModel(Proiect_Daniela.Data.DanielaDbContext context)
        {
            _context = context;
        }

      public Departament Departament { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Departament == null)
            {
                return NotFound();
            }

            var departament = await _context.Departament.FirstOrDefaultAsync(m => m.ID == id);
            if (departament == null)
            {
                return NotFound();
            }
            else 
            {
                Departament = departament;
            }
            return Page();
        }
    }
}
