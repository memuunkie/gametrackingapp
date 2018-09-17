using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace PingPong.Models
{
    public class SingleGame
    {
        public static SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PingPong"].ConnectionString);

        public int Id { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public string PlayerWinner => Player1Score > Player2Score ?
                                    Player1.FirstName : Player2.FirstName;
        // set PlayerWinner
        public List<Player> Players { get; set; }
        public DateTime CreationDate { get; set; }

        // set the CreationDate to now
        public SingleGame()
        {
            CreationDate = DateTime.Now;
            Players = Player.Get();
        }

        public static List<SingleGame> Get()
        {
            // list of all SingleGames
            var games = _conn.Query<SingleGame, Player, Player, SingleGame>(@"SELECT sg.*, p1.*, p2.*
                                                FROM SingleGames sg
                                                INNER JOIN Players p1 on p1.Id = sg.Player1Id
                                                INNER JOIN Players p2 on p2.Id = sg.Player2Id;",
                                                (sg, p1, p2) =>
                                                {
                                                    // bind the table/class hybrid to the property
                                                    sg.Player1 = p1;
                                                    sg.Player2 = p2;
                                                    return sg;
                                                }).ToList();

            return games;
        }

        public static List<SingleGame> GetGamesByPlayerId(int playerId)
        {
            // list of SingleGames based on player's id
            var games = _conn.Query<SingleGame, Player, Player, SingleGame>(@"SELECT sg.*, p1.*, p2.*
                                                FROM SingleGames sg
                                                INNER JOIN Players p1 on p1.Id = sg.Player1Id
                                                INNER JOIN Players p2 on p2.Id = sg.Player2Id
                                                WHERE Player1Id=@playerId OR Player2Id=@playerId
                                                ORDER BY sg.CreationDate DESC", 
                                                (sg, p1, p2) =>
                                                {
                                                    // bind the table/class hybrid to the property
                                                    sg.Player1 = p1;
                                                    sg.Player2 = p2;
                                                    return sg;
                                                }, new {playerId}).ToList();

            return games;
        }
    }
}