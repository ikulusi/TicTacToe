using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticTacToe.Logic
{
    public class Player
    {
        int player;

        public Player()
        {
            player = 0;
        }

        public void Reset()
        {
            player = 0;
        }

        public void ChangePlayer()
        {
            player += 1;
            player %= 2;
        }

        public string Who()
        {
            if (player == 0) return "o";
            else return "x";
        }
    }
}
