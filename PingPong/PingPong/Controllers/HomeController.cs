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
            // this is debugging code to test TeamGame methods, not used on Index
            var teams = TeamGame.Get();
            return View(teams);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            ViewBag.Message = "Single Games!";
            var games = SingleGame.Get();
            var teamGames = TeamGame.Get();
            var model = new GameViewModel { SingleGames = games, TeamGames = teamGames };

            return View(model);
        }

        public ActionResult Players()
        {
            // redirecting to the Index on PlayerController
            return RedirectToAction("Index", "Players");

        }

        public ActionResult Games()
        {
            // redirecting to the Index on GamesController
            return RedirectToAction("Index", "Games");
        }
    }
}