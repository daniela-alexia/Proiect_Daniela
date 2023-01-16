using Microsoft.AspNetCore.Identity;

namespace Proiect_Daniela.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public String FirstName { get; set; }   
        public String LastName { get; set; }   
    }
}
