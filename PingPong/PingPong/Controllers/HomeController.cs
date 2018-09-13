using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Dapper;
using PingPong.Models;
using PingPong.ViewModel;

namespace PingPong.Controllers
{
    public class HomeController : Controller
    {
        readonly SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PingPong"].ConnectionString);
        // creates connection to database
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //var games = TeamGame.GetGamesByTeamIds();

            var gameWinners = TeamGame.Get();

            var singleGames = SingleGame.GetGamesByPlayerId(1);



            return View();
        }

        public ActionResult Players()
        {
            return RedirectToAction("Index", "Players");

        }
    }
}