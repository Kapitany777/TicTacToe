using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public static class TicTacToeHelper
    {
        public static TicTacToeSign Opponent(TicTacToeSign sign)
        {
            if (sign == TicTacToeSign.Sign_X)
                return TicTacToeSign.Sign_O;
            else if (sign == TicTacToeSign.Sign_O)
                return TicTacToeSign.Sign_X;
            else
                return TicTacToeSign.Empty;
        }
    }
}
