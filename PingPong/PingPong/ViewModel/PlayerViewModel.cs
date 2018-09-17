using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PingPong.Models;

namespace PingPong.ViewModel
{
    public class PlayerViewModel
    {
        public List<Player> Players { get; set; }

        public List<SingleGame> SingleGames { get; set; }

        public List<TeamGame> TeamGames { get; set; }
    }
}