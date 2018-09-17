using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PingPong.Models
{
    public class Team
    {
        public static SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PingPong"].ConnectionString);

        public int Id { get; set; }

        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public string TeamName { get; set; }
        public DateTime CreationDate { get; set; }

        // set the CreationDate to now
        public Team()
        {
            CreationDate = DateTime.Now;
        }

        public static List<Team> Get()
        {
            return _conn.Query<Team>("SELECT * FROM Teams").ToList();
        }
    }
}