﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Daniela.Data;
using Proiect_Daniela.Models.Domain;

namespace Proiect_Daniela.Pages.Departamente
{
    public class EditModel : PageModel
    {
        private readonly Proiect_Daniela.Data.DanielaDbContext _context;

        public EditModel(Proiect_Daniela.Data.DanielaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Departament Departament { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Departament == null)
            {
                return NotFound();
            }

            var departament =  await _context.Departament.FirstOrDefaultAsync(m => m.ID == id);
            if (departament == null)
            {
                return NotFound();
            }
            Departament = departament;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Departament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentExists(Departament.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DepartamentExists(Guid id)
        {
          return _context.Departament.Any(e => e.ID == id);
        }
    }
}
