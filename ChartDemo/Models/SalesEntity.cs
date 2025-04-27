using System.ComponentModel.DataAnnotations;

namespace ChartDemo.Models
{
    public class SalesEntity
    {
        [Key]
        public int Id { get; set; }
        public string MonthName { get; set; } = string.Empty;
        public int TotalSales { get; set; }
    }
}
