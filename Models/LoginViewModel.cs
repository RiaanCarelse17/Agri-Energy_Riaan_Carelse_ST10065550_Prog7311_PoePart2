using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Riaan_Carelse_ST10065550_Prog7311_PoePart2.Models
{
    public class LoginViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string UserType { get; set; } // "Farmer" or "Employee"
    }
}