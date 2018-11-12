using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class GameAISimple1 : GameAIAbstract
    {
        public GameAISimple1(TicTacToeBoard board)
            : base(board)
        {
        }

        public override bool GetNextMove(TicTacToeSign sign, out int row, out int column)
        {
            Steps = 0;
            
            row = -1;
            column = -1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Steps++;
                    
                    if (board.CorrectMove(i, j))
                    {
                        row = i;
                        column = j;

                        break;
                    }
                }

                if (row != -1)
                    break;
            }

            return (row != -1);
        }
    }
}
