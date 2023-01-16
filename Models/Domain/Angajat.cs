namespace Proiect_Daniela.Models.Domain
{
    public class Angajat
    {
        // id unic
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public long Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Department { get; set; }


    }
}
