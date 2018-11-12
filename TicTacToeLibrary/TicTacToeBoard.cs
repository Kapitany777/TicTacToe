using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class TicTacToeBoard
    {
        private TicTacToeSign[,] board;

        public void Reset()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = TicTacToeSign.Empty;
                }
            }
        }

        public TicTacToeSign GetSign(int row, int column)
        {
            return board[row, column];
        }

        public TicTacToeSign GetSign(int position)
        {
            return board[(int)(position / 3), position % 3];
        }

        public void SetSign(int row, int column, TicTacToeSign sign)
        {
            board[row, column] = sign;
        }

        public void SetSign(int position, TicTacToeSign sign)
        {
            board[(int)(position / 3), position % 3] = sign;
        }

        public bool CorrectMove(int row, int column)
        {
            return GetSign(row, column) == TicTacToeSign.Empty;
        }

        public int EmptyCount()
        {
            int cnt = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == TicTacToeSign.Empty)
                        cnt++;
                }
            }

            return cnt;
        }

        public TicTacToeResult Winner()
        {
            TicTacToeResult res = TicTacToeResult.None;
            TicTacToeSign sign = TicTacToeSign.Empty;

            if (((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) ||
                 (board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2]) ||
                 (board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0])) &&
                 board[0, 0] != TicTacToeSign.Empty)
            {
                sign = board[0, 0];
            }
            else if (((board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]) ||
                      (board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2])) &&
                      board[0, 2] != TicTacToeSign.Empty)
            {
                sign = board[0, 2];
            }
            else if (board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2] && board[1, 0] != TicTacToeSign.Empty)
            {
                sign = board[1, 0];
            }
            else if (board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2] && board[2, 0] != TicTacToeSign.Empty)
            {
                sign = board[2, 0];
            }
            else if (board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1] && board[0, 1] != TicTacToeSign.Empty)
            {
                sign = board[0, 1];
            }

            if (sign == TicTacToeSign.Empty)
            {
                if (EmptyCount() == 0)
                    res = TicTacToeResult.Draw;
            }
            else if (sign == TicTacToeSign.Sign_X)
            {
                res = TicTacToeResult.Player_X;
            }
            else
            {
                res = TicTacToeResult.Player_O;
            }

            return res;
        }

        public bool IsXOrEmpty(int row, int column)
        {
            return board[row, column] == TicTacToeSign.Sign_X ||
                   board[row, column] == TicTacToeSign.Empty;
        }

        public bool IsOOrEmpty(int row, int column)
        {
            return board[row, column] == TicTacToeSign.Sign_O ||
                   board[row, column] == TicTacToeSign.Empty;
        }

        public int FreeX()
        {
            int cnt = 0;

            if (IsXOrEmpty(0, 0) && IsXOrEmpty(0, 1) && IsXOrEmpty(0, 2))
                cnt++;

            if (IsXOrEmpty(0, 0) && IsXOrEmpty(1, 0) && IsXOrEmpty(2, 0))
                cnt++;

            if (IsXOrEmpty(0, 0) && IsXOrEmpty(1, 1) && IsXOrEmpty(2, 2))
                cnt++;

            if (IsXOrEmpty(0, 1) && IsXOrEmpty(1, 1) && IsXOrEmpty(2, 1))
                cnt++;

            if (IsXOrEmpty(0, 2) && IsXOrEmpty(1, 2) && IsXOrEmpty(2, 2))
                cnt++;

            if (IsXOrEmpty(1, 0) && IsXOrEmpty(1, 1) && IsXOrEmpty(1, 2))
                cnt++;

            if (IsXOrEmpty(2, 0) && IsXOrEmpty(2, 1) && IsXOrEmpty(2, 2))
                cnt++;

            if (IsXOrEmpty(0, 2) && IsXOrEmpty(1, 1) && IsXOrEmpty(2, 0))
                cnt++;

            return cnt;
        }

        public int FreeO()
        {
            int cnt = 0;

            if (IsOOrEmpty(0, 0) && IsOOrEmpty(0, 1) && IsOOrEmpty(0, 2))
                cnt++;

            if (IsOOrEmpty(0, 0) && IsOOrEmpty(1, 0) && IsOOrEmpty(2, 0))
                cnt++;

            if (IsOOrEmpty(0, 0) && IsOOrEmpty(1, 1) && IsOOrEmpty(2, 2))
                cnt++;

            if (IsOOrEmpty(0, 1) && IsOOrEmpty(1, 1) && IsOOrEmpty(2, 1))
                cnt++;

            if (IsOOrEmpty(0, 2) && IsOOrEmpty(1, 2) && IsOOrEmpty(2, 2))
                cnt++;

            if (IsOOrEmpty(1, 0) && IsOOrEmpty(1, 1) && IsOOrEmpty(1, 2))
                cnt++;

            if (IsOOrEmpty(2, 0) && IsOOrEmpty(2, 1) && IsOOrEmpty(2, 2))
                cnt++;

            if (IsOOrEmpty(0, 2) && IsOOrEmpty(1, 1) && IsOOrEmpty(2, 0))
                cnt++;

            return cnt;
        }

        public int FreeDirection(TicTacToeSign sign)
        {
            if (sign == TicTacToeSign.Sign_X)
                return FreeX();
            else
                return FreeO();
        }

        public TicTacToeBoard()
        {
            board = new TicTacToeSign[3, 3];

            Reset();
        }

        public TicTacToeBoard(TicTacToeBoard otherBoard)
        {
            board = new TicTacToeSign[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = otherBoard.GetSign(i, j);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder table = new StringBuilder(32);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    TicTacToeSign sign = board[i, j];

                    if (sign == TicTacToeSign.Sign_X)
                        table.Append('X');
                    else if (sign == TicTacToeSign.Sign_O)
                        table.Append('O');
                    else
                        table.Append(' ');
                }

                table.Append(Environment.NewLine);
            }
            
            return table.ToString();
        }
    }
}
