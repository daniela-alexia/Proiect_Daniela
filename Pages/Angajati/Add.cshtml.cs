using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Daniela.Data;
using Proiect_Daniela.Models.Domain;
using Proiect_Daniela.Models.ViewModels;

namespace Proiect_Daniela.Pages.Angajati
{
    public class AddModel : PageModel

    {
        private readonly DanielaDbContext dbContext;

        //injectam db context
        public AddModel(DanielaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        // folosim bind atribut ca sa il legam de form (de rezor page: Add.cshtml)
        [BindProperty]
        public AdaugareAngajatViewModel AddEmployeeRequest { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            // comvertim ViewModel to DomainModel

            var angajatDomainModel = new Angajat
            {
                Name = AddEmployeeRequest.Name,
                Email = AddEmployeeRequest.Email,
                Salary = AddEmployeeRequest.Salary,
                DateOfBirth = AddEmployeeRequest.DateOfBirth,
                Department = AddEmployeeRequest.Department
            };

            // ii transmitem dbContextului sa adauge noul angajat
            dbContext.Angajati.Add(angajatDomainModel);
            // salvam schimbarile
            dbContext.SaveChanges();

            ViewData["Message"] = "Angajatul a fost adaugat cu succes!";
        }
    }
}
