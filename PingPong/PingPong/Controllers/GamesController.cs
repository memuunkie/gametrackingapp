﻿using System;
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
    public class GamesController : Controller
    {
        readonly SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PingPong"].ConnectionString);
        // creates connection to database

        // GET: Games
        public ActionResult Index()
        {
            ViewBag.Message = "Games!";
            var singleGames = SingleGame.Get();
            var teamGames = TeamGame.Get();

            foreach (var game in singleGames)
            {
                game.PlayerWinner = game.GetPlayerWinnerId();
            }

            foreach (var game in teamGames)
            {
                game.TeamWinner = game.GetTeamWinnerName();
            }

            Dictionary<string, int> winnerCount = new Dictionary<string, int>();

            foreach (var game in teamGames)
            {
                if (!winnerCount.ContainsKey(game.TeamWinner))
                {
                    winnerCount[game.TeamWinner] = 1;
                }
                else
                {
                    winnerCount[game.TeamWinner]++;
                }
            }

            var winnerCountList = winnerCount.ToList();

            winnerCountList.Sort((y,x) => x.Value.CompareTo(y.Value));

            var model = new GameViewModel { SingleGames = singleGames, TeamGames = teamGames, TeamLeaders = winnerCountList, Rank = 1};

            return View(model);
        }

        // GET: Games/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Player1Id,Player2Id,Player1Score,Player2Score")] SingleGame singleGame)
        {

            using (_conn)
            {
                _conn.Execute(@"INSERT INTO SingleGames (Player1Id,Player2Id,Player1Score,Player2Score,CreationDate) 
                                VALUES (@Player1Id, @Player2Id, @Player1Score, @Player2Score, @CreationDate);", singleGame);
            }

            return RedirectToAction("Index", "Games");
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Games/Edit/5
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

        // GET: Games/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Games/Delete/5
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
    }
}
