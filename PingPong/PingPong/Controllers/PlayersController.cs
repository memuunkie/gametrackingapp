using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PingPong.Models;
using Dapper;
using PingPong.ViewModel;
using System.Net;

namespace PingPong.Controllers
{
    public class PlayersController : Controller
    {
        readonly SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PingPong"].ConnectionString);
        // creates connection to database

        // GET: Players
        public ActionResult Index()
        {
            ViewBag.Message = "Players!";
            var players = Player.Get();
            var model = new PlayerViewModel { Players = players};

            var teamName = Player.GetTeams(1);

            return View(model);
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string sql = "SELECT * FROM Players WHERE Id='" + id + "'";

            Player player;
            // ^ strongly typed vs wimpy var player = new Player();

            using (_conn)
            {
                player = _conn.QuerySingle<Player>(sql);
            }

            player.Teams = Player.GetTeams(player.Id);
            player.SingleGames = SingleGame.GetGamesByPlayerId(player.Id);

            var playerTeamIds = player.Teams.Select(x => x.Id);

            player.TeamGames = TeamGame.GetGamesByTeamIds(playerTeamIds);

            return View(player);

        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName")] Player player)
        {
            using (_conn)
            {
                _conn.Execute(@"INSERT INTO Players (FirstName,LastName,CreationDate) 
                                VALUES (@FirstName, @LastName, @CreationDate);", player);
            }

            return RedirectToAction("Index", "Players");
        }


        // GET: Players/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Players/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Players/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //KEEP UNTIL PROVEN UNNECESSARY
        //public ActionResult Players()
        //{
        //    ViewBag.Message = "Players!";
        //    var players = Player.Get();
        //    var model = new PlayerViewModel { Players = players };

        //    return View(model);
        //}
    }
}
