using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class GameAIRule : GameAIAbstract
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

        public GameAIRule(TicTacToeBoard board)
            : base(board)
        {
        }

        public override bool GetNextMove(TicTacToeSign sign, out int row, out int column)
        {
            Steps = 0;
            
            row = -1;
            column = -1;

            // Ha egy adott lépéssel megnyerné a gép a játékot, akkor ezt a lépést kell választani
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Steps++;
                    
                    if (board.GetSign(i, j) == TicTacToeSign.Empty)
                    {
                        board.SetSign(i, j, sign);

                        if (board.Winner() != TicTacToeResult.None)
                        {
                            row = i;
                            column = j;

                            board.SetSign(i, j, TicTacToeSign.Empty);
                            break;
                        }

                        board.SetSign(i, j, TicTacToeSign.Empty);
                    }
                }

                if (row != -1)
                    break;
            }

            if (row != -1)
            {
                return true;
            }

            // Ha egy adott lépéssel az ellenfél nyerné meg a játékot, akkor erre a helyre lépve blokkolni kell az ő lépését
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Steps++;
                    
                    if (board.GetSign(i, j) == TicTacToeSign.Empty)
                    {
                        board.SetSign(i, j, TicTacToeHelper.Opponent(sign));

                        if (board.Winner() != TicTacToeResult.None)
                        {
                            row = i;
                            column = j;

                            board.SetSign(i, j, TicTacToeSign.Empty);
                            break;
                        }

                        board.SetSign(i, j, TicTacToeSign.Empty);
                    }
                }
            }

            if (row != -1)
            {
                return true;
            }

            // Egyébként táblázat alapján választunk az üres helyek közül
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
