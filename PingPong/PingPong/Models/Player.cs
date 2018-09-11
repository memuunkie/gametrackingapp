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
        // optional - can refactor into separate Database class for easy reference
        public static SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PingPong"].ConnectionString);

        // creates connection to database
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public DateTime CreationDate { get; set; }

        // set the CreationDate to now
        public Player()
        {
            this.CreationDate = DateTime.Now;
        }

        public static List<Player> Get()
        {
            return _conn.Query<Player>("SELECT * FROM Players").ToList();
        }
    }
}