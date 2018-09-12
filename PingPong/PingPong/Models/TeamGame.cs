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
        public Team Team1 { get; set; }
        // this is "binding" the teams to the Team class using their "ids" (thru Dapper magic)
        public Team Team2 { get; set; }
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
            // a list of all TeamGames records

            return _conn.Query<TeamGame>("SELECT * FROM TeamGames").ToList();
        }

        public static List<TeamGame> GetGamesbyTeamIds(int[] teamIds)
        {
            // pass in ids to find
            // add Classes to "bind" results to
            // <FirstTable-tg, SecondTableJoin-t1, ThirdTableJoin-t2, FinalObjectReturned>

            var games = _conn.Query<TeamGame, Team, Team, TeamGame>(@"SELECT tg.*, t1.*, t2.*
                            FROM TeamGames tg
                            INNER JOIN Teams t1 ON t1.Id = tg.Team1Id
                            INNER JOIN Teams t2 ON t2.Id = tg.Team2Id
                            WHERE Team1Id IN @teamIds OR Team2Id IN @teamIds;",
                (tg, t1, t2) =>
                {
                    // bind the table/class hybrid to the property
                    tg.Team1 = t1;
                    tg.Team2 = t2;
                    return tg;
                }, new {teamIds}).ToList();
                    // don't forget to pass in the parameter and then List the result

            return games;
        }

    }
}