using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class GameAIStatic1 : GameAIAbstract
    {
        public GameAIStatic1(TicTacToeBoard board)
            : base(board)
        {
        }

        public override bool GetNextMove(TicTacToeSign sign, out int row, out int column)
        {
            Steps = 0;
            
            row = -1;
            column = -1;

            int rowtmp = -1;
            int columntmp = -1;
            int max = -100;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.CorrectMove(i, j))
                    {
                        Steps++;
                        
                        board.SetSign(i, j, sign);

                        if (board.Winner() != TicTacToeResult.None)
                        {
                            row = i;
                            column = j;

                            board.SetSign(i, j, TicTacToeSign.Empty);
                            break;
                        }
                        else
                        {
                            int e = board.FreeDirection(sign) - board.FreeDirection(TicTacToeHelper.Opponent(sign));

                            if (e > max)
                            {
                                max = e;

                                rowtmp = i;
                                columntmp = j;
                            }
                        }

                        board.SetSign(i, j, TicTacToeSign.Empty);
                    }
                }

                if (row != -1)
                    break;
            }

            if (row == -1)
            {
                row = rowtmp;
                column = columntmp;
            }

            return (row != -1);
        }
    }
}
