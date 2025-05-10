namespace Agri_Energy_Riaan_Carelse_ST10065550_Prog7311_PoePart2.Models
{
    public class Product
    {
        public int ProductId { get; set; } // PK
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime ProductionDate { get; set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
    }
}
