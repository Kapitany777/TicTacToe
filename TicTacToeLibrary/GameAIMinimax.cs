using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TicTacToeLibrary
{
    public class GameAIMinimax : GameAIAbstract, IGameAIMinimax
    {
        public int BestResult { get; private set; }
        
        public GameAIMinimax(TicTacToeBoard board)
            : base(board)
        {
            BestResult = 0;
        }

        public int GetBestResult()
        {
            return BestResult;
        }

        private int PlayMin(TicTacToeBoard prevBoard, TicTacToeSign sign)
        {
            int min = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (prevBoard.CorrectMove(i, j))
                    {
                        TicTacToeBoard newBoard = new TicTacToeBoard(prevBoard);
                        newBoard.SetSign(i, j, sign);

                        Steps++;

                        TicTacToeResult result = newBoard.Winner();

                        if (result != TicTacToeResult.None)
                        {
                            if (result == TicTacToeResult.Draw)
                            {
                                if (min > 0)
                                    min = 0;
                            }
                            else
                            {
                                min = -1;
                            }
                        }
                        else
                        {
                            int min1 = PlayMax(newBoard, TicTacToeHelper.Opponent(sign));

                            if (min1 < min)
                                min = min1;
                        }
                    }
                }
            }

            return min;
        }

        private int PlayMax(TicTacToeBoard prevBoard, TicTacToeSign sign)
        {
            int max = -1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (prevBoard.CorrectMove(i, j))
                    {
                        TicTacToeBoard newBoard = new TicTacToeBoard(prevBoard);
                        newBoard.SetSign(i, j, sign);

                        Steps++;

                        TicTacToeResult result = newBoard.Winner();

                        if (result != TicTacToeResult.None)
                        {
                            if (result == TicTacToeResult.Draw)
                            {
                                if (max < 0)
                                    max = 0;
                            }
                            else
                            {
                                max = 1;
                            }
                        }
                        else
                        {
                            int max1 = PlayMin(newBoard, TicTacToeHelper.Opponent(sign));

                            if (max1 > max)
                                max = max1;
                        }
                    }
                }
            }

            return max;
        }

        public override bool GetNextMove(TicTacToeSign sign, out int row, out int column)
        {
            row = -1;
            column = -1;

            Steps = 0;
            int max = -1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.CorrectMove(i, j))
                    {
                        TicTacToeBoard newBoard = new TicTacToeBoard(board);
                        newBoard.SetSign(i, j, sign);

                        Steps++;

                        TicTacToeResult result = newBoard.Winner();

                        if (result != TicTacToeResult.None)
                        {
                            if (result == TicTacToeResult.Draw)
                            {
                                if (max < 0)
                                {
                                    max = 0;
                                    row = i;
                                    column = j;
                                }
                            }
                            else
                            {
                                max = 1;
                                row = i;
                                column = j;
                            }
                        }
                        else
                        {
                            int max1 = PlayMin(newBoard, TicTacToeHelper.Opponent(sign));

                            if (max1 > max)
                            {
                                max = max1;
                                row = i;
                                column = j;
                            }
                        }
                    }
                }
            }

            Debug.WriteLine(String.Format("Sor: {0} Oszlop: {1} Érték: {2} Vizsgálatok: {3}", row, column, max, Steps));
            // MessageBox.Show(String.Format("Sor: {0} Oszlop: {1} Érték: {2} Vizsgálatok: {3}", row, column, max, count));

            BestResult = max;

            return (row != -1);
        }
    }
}
