using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace PingPong.Models
{
    public class TeamGame
    {
        public static SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PingPong"].ConnectionString);

        public int Id { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public DateTime CreationDate { get; set; }

        // set the CreationDate to now
        public TeamGame()
        {
            this.CreationDate = DateTime.Now;
        }

        public static List<TeamGame> Get()
        {
            return _conn.Query<TeamGame>("SELECT * FROM TeamGames").ToList();
        }
    }
}