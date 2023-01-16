using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Proiect_Daniela.Data;
using Proiect_Daniela.Models.ViewModels;

namespace Proiect_Daniela.Pages.Angajati
{
    public class EditModel : PageModel
    {
        private readonly DanielaDbContext dbContext;

        [BindProperty]
        public EditareAngajatViewModel EditareAngajatViewModel { get; set; }

        public EditModel(DanielaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void OnGet(Guid id)
        {
            var angajat = dbContext.Angajati.Find(id);
            
            if (angajat != null)
            {
                // Convert Domain Model to view Model
                EditareAngajatViewModel = new EditareAngajatViewModel()
                {
                    Id = angajat.Id,
                    Name = angajat.Name,
                    Email = angajat.Email,
                    Salary = angajat.Salary,
                    Department = angajat.Department
                };
            }
        }
        // aici venim dupa ce dam submit la form
        public void OnPostUpdate()
        {

            if(EditareAngajatViewModel != null)
            {
               var existingEmployee = dbContext.Angajati.Find(EditareAngajatViewModel.Id);

                if(existingEmployee != null)
                {
                    // Convert ViewModel in DomainModel
                    existingEmployee.Name = EditareAngajatViewModel.Name;
                    existingEmployee.Email = EditareAngajatViewModel.Email;
                    existingEmployee.Salary = EditareAngajatViewModel.Salary;
                    existingEmployee.DateOfBirth = EditareAngajatViewModel.DateOfBirth;
                    existingEmployee.Department = EditareAngajatViewModel.Department;

                    dbContext.SaveChanges();
                    ViewData["Message"] = "Detaliile despre angajat au fost modificate cu succes";
                    
                }
            }

        }

        public IActionResult OnPostDelete()
        {
            var angajatExistent = dbContext.Angajati.Find(EditareAngajatViewModel.Id); 

            if (angajatExistent != null)
            {
                dbContext.Angajati.Remove(angajatExistent);
                dbContext.SaveChanges();

                //dupa ce am sters angajatul ne intoarcem la lista
                return RedirectToPage("/Angajati/List");
            }
            return Page();
        }
    }
}
