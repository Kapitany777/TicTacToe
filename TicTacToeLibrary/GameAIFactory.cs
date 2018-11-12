using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public static class GameAIFactory
    {
        public static GameAIAbstract GetGameAI(GameAIType AIType, TicTacToeBoard board)
        {
            GameAIAbstract ai = null;

            switch (AIType)
            {
                case GameAIType.Simple1:
                    ai = new GameAISimple1(board);
                    break;

                case GameAIType.Simple2:
                    ai = new GameAISimple2(board);
                    break;

                case GameAIType.Position:
                    ai = new GameAIPosition(board);
                    break;

                case GameAIType.Static1:
                    ai = new GameAIStatic1(board);
                    break;

                case GameAIType.Rule:
                    ai = new GameAIRule(board);
                    break;

                case GameAIType.Minimax:
                    ai = new GameAIMinimax(board);
                    break;
            }

            return ai;
        }
    }
}
