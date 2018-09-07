using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Dapper;
using PingPong.Models;

namespace PingPong.Controllers
{
    public class HomeController : Controller
    {
        readonly SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PingPong"].ConnectionString);
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var players = new List<Player>();
            players = _conn.Query<Player>("SELECT * FROM Players").ToList();

            return View();
        }
    }
}