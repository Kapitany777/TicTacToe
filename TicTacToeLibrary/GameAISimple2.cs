using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class GameAISimple2 : GameAIAbstract
    {
        public GameAISimple2(TicTacToeBoard board)
            : base(board)
        {
        }

        public override bool GetNextMove(TicTacToeSign sign, out int row, out int column)
        {
            Steps = 0;
            
            row = -1;
            column = -1;

            List<Position> plist = new List<Position>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Steps++;
                    
                    if (board.CorrectMove(i, j))
                    {
                        plist.Add(new Position(i, j));
                    }
                }
            }

            if (plist.Count != 0)
            {
                Random rnd = new Random();

                Position p = plist[rnd.Next(plist.Count)];

                row = p.Row;
                column = p.Column;
            }

            return (plist.Count != 0);
        }
    }
}
