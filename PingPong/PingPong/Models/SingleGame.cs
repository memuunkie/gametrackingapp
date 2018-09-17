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
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public int PlayerWinner { get; set; }
        public int GetPlayerWinnerId() => Player1Score > Player2Score ? Player1Id : Player2Id;
        // set PlayerWinner
        public DateTime CreationDate { get; set; }

        // set the CreationDate to now
        public SingleGame()
        {
            this.CreationDate = DateTime.Now;
        }

        public static List<SingleGame> Get()
        {
            // list of all SingleGames
            var games = _conn.Query<SingleGame>("SELECT * FROM SingleGames").ToList();

            return games;
        }

        public static List<SingleGame> GetGamesByPlayerId(int playerId)
        {
            // list of SingleGames based on player's id
            var games = _conn.Query<SingleGame>(@"SELECT * FROM SingleGames 
                                                WHERE Player1Id=@playerId OR Player2Id=@playerId
                                                ORDER BY CreationDate DESC", new {playerId}).ToList();

            return games;
        }
    }
}