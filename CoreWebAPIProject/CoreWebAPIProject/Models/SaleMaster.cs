using System.ComponentModel.DataAnnotations;

namespace CoreWebAPIProject.Models
{
    public class SaleMaster
    {
        [Key]
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public DateTime SaleDate { get; set; }

        public ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}
