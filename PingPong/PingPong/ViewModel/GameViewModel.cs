using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PingPong.Models;

namespace PingPong.ViewModel
{
    public class GameViewModel
    {
        public List<TeamGame> TeamGames { get; set; }

        public List<SingleGame> SingleGames { get; set; }
    }
}