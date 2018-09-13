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
        public DateTime CreationDate { get; set; }

        // set the CreationDate to now
        public SingleGame()
        {
            this.CreationDate = DateTime.Now;
        }

        public static List<SingleGame> Get()
        {
            // list of all SingleGames
            return _conn.Query<SingleGame>("SELECT * FROM SingleGames").ToList();

        }

        public static List<SingleGame> GetGamesByPlayerId(int playerId)
        {
            // list of SingleGames based on player's id
            var games = _conn.Query<SingleGame>(@"SELECT * FROM SingleGames 
                                                WHERE Player1Id=@playerId OR Player2Id=@playerId", new {playerId}).ToList();

            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].Player1Score > games[i].Player2Score)
                {
                    games[i].PlayerWinner = games[i].Player1Id;
                }
                else
                {
                    games[i].PlayerWinner = games[i].Player2Id;
                }
            }

            return games;

        }
    }
}