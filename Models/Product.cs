using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Riaan_Carelse_ST10065550_Prog7311_PoePart2.Models
{
    public class Product
    {
        public int ProductId { get; set; } // PK

        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Production date is required")]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }    

        public int FarmerId { get; set; }
        public Farmer? Farmer { get; set; }
    }
}
