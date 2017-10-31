using CardGameManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameManager.GameProcesses
{
    public class BlackjackGame
    {
        List<Player> players;

        public BlackjackGame(List<Player> players1)
        {
            players = players1;
        }
    }
}
