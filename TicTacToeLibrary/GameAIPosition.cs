using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class GameAIPosition : GameAIAbstract
    {
        List<Position> bestMoves = new List<Position>
        {
            new Position(1, 1),
            new Position(0, 0),
            new Position(0, 2),
            new Position(2, 0),
            new Position(2, 2),
            new Position(0, 1),
            new Position(1, 0),
            new Position(1, 2),
            new Position(2, 1)
        };
        
        public GameAIPosition(TicTacToeBoard board)
            : base(board)
        {
        }

        public override bool GetNextMove(TicTacToeSign sign, out int row, out int column)
        {
            Steps = 0;
            
            row = -1;
            column = -1;

            for (int i = 0; i < bestMoves.Count; i++)
            {
                Steps++;
                
                if (board.GetSign(bestMoves[i].Row, bestMoves[i].Column) == TicTacToeSign.Empty)
                {
                    row = bestMoves[i].Row;
                    column = bestMoves[i].Column;

                    break;
                }
            }

            return (row != -1);
        }
    }
}
