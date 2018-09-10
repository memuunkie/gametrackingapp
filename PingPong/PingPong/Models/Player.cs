using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Web;

namespace PingPong.Models
{
    public class Player
    {
        public static SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PingPong"].ConnectionString);
        // creates connection to database
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public static List<Player> Get()
        {
            return _conn.Query<Player>("SELECT * FROM Players").ToList();
        }
    }
}