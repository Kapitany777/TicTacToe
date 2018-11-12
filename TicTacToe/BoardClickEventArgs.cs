using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class BoardClickEventArgs : EventArgs
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public BoardClickEventArgs(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
