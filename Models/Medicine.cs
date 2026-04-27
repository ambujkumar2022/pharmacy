using System.Text;

namespace pharmacy.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
    }
}
