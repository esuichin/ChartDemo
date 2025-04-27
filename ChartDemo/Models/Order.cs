using System.ComponentModel.DataAnnotations;

namespace ChartDemo.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string MonthName { get; set; } = string.Empty;
        public int TotalOrders { get; set; }
    }
}
