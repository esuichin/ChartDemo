using ChartDemo.Data;
using Microsoft.AspNetCore.Mvc;

namespace ChartDemo.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DbContextSales _context;

        public CustomerController(DbContextSales context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowSalesData()
        {
            return View();
        }
        [HttpPost]
        public List<object> GetSalesData()
        {
            List<object> data = new List<object>();
            List<string> labels = _context.SalesData.Select(s => s.MonthName).ToList();
            data.Add(labels);

            List<int> SalesNumber = _context.SalesData.Select(s => s.TotalSales).ToList();
            data.Add(SalesNumber);

            return data;            
        }
    }
}
