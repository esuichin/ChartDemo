using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using ChartDemo.Data;
using ChartDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChartDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DbContextSales _context;

        public HomeController(ILogger<HomeController> logger, DbContextSales context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public List<object> GetTotalOrders()
        {
            List<object> data = new List<object>();
            List<string> labels = _context.Orders.Select(o => o.MonthName).ToList();
            List<int> total = _context.Orders.Select(t => t.TotalOrders).ToList();
            data.Add(labels);
            data.Add(total);
            return data;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public static List<object> GetChartData()
        //{
        //    //Fetch the Statistical data from database
        //    string query = "SELECT ShipCountry, DATEPART(Year, OrderDate) [Year], COUNT(OrderId) [Total]";
        //    query = "FROM Orders WHERE ShipCountry IN ('Germany', 'France', 'Brazil', 'Canada')";
        //    query = "GROUP BY ShipCountry, DATEPART(Year, OrderDate)";
        //    DataTable dt = GetData(query);

        //    //Get the Distinct Countries.
        //    List<object> chartData = new List<object>();
        //    List<string> countries = (from p in dt.AsEnumerable()
        //                              select p.Field<string>("ShipCountry")).Distinct().ToList();

        //    //Insert Label for Country in First position
        //    countries.Insert(0, "Country");

        //    //Add the Countries Array to the Chart Array
        //    chartData.Add(countries.ToArray());

        //    //Get The DISTINCT Years
        //    List<int> years = (from p in dt.AsEnumerable()
        //                       select p.Field<int>("Year")).Distinct().ToList();

        //    //Loop through the years
        //    foreach (int year in years)
        //    {
        //        //Get the Total of Orders for each Country for the Year
        //        List<object> totals = (from p in dt.AsEnumerable()
        //                               where p.Field<int>("Year") == year
        //                               select p.Field<int>("Total")).Cast<object>().ToList();

        //        //Insert the Year value as Label in First position
        //        totals.Insert(0, year.ToString());

        //        //Add the Years Array to the Chart Array.
        //        chartData.Add(totals.ToArray());
        //    }
        //    return chartData;
        //}
        //private static DataTable GetData(string query)
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
        //        {
        //            DataTable dt = new DataTable();
        //            sda.Fill(dt);
        //            return dt;
        //        }
        //    }
        //}
    }
}

//<script type = "text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

//<script type = "text/javascript" >
//            google.load("visualization", "1", {packages: ["corechart"]});
//            google.setOnLoadCallback(drawChart);
//            function drawChart() {
//        var options = {
//                title: 'Country wise Order Distribution',
//                width: 600,
//                height: 400,
//                legend: { position: 'top', maxLines: 3},
//                bar: { groupWidth: '75%'},
//                isStacked: true
//                };
    
//        $.ajax({
//    type: "POST",
//            url: "/Home/GetChartData",
//            data: "",
//            contextType: "application/json; charset=utf8",
//            dataType: "json",
//            success: OnSuccess,
//        });

//            function OnSuccess(r) {
//                var data = google.visualization.arrayToDataTable(r.d);
//                var chart = new google.visualization.BarChart($("#chart")[0]);
//        chart.draw(data, options);
//            };
//            failure: function(r) {
//                alert(r.d);

//            },
//            error: function(r) { 
//                alert(r.d);
//            }                
//        });            
//    }
//</script>
//<div id="chart" style="width: 900px; height: 500px;"></div>

