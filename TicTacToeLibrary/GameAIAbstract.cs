using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public abstract class GameAIAbstract
    {
        protected TicTacToeBoard board;

        private int steps;

        public int Steps
        {
            get
            {
                return steps;
            }

            protected set
            {
                steps = value;
            }
        }

        public GameAIAbstract(TicTacToeBoard board)
        {
            this.board = board;
            this.steps = 0;
        }

        public abstract bool GetNextMove(TicTacToeSign sign, out int row, out int column);
    }
}
