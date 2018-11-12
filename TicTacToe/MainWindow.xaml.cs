using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToeLibrary;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserControlBoard playingBoard;
        TicTacToeBoard gameBoard;
        GameAIAbstract gameAIX;
        GameAIAbstract gameAIO;

        TicTacToeSign playerSign;

        Stopwatch stopWatch;

        public MainWindow()
        {
            InitializeComponent();

            CreateGameBoard();
            CreateBoard();
            CreateAI();

            NewGame();
        }

        private void CreateGameBoard()
        {
            gameBoard = new TicTacToeBoard();
        }

        private void CreateBoard()
        {
            playingBoard = new UserControlBoard();

            playingBoard.SetValue(Grid.RowProperty, 0);
            playingBoard.SetValue(Grid.ColumnProperty, 0);
            playingBoard.Background = new SolidColorBrush(Color.FromArgb(255, 180, 180, 180));
            playingBoard.Margin = new Thickness(10, 10, 10, 10);

            playingBoard.BoardClick += board_BoardClick;

            stopWatch = new Stopwatch();

            GridMain.Children.Add(playingBoard);
        }

        private void CreateAI()
        {
            SetGameAIX();
            SetGameAIO();
        }

        private void SetGameAIX()
        {
            foreach (RadioButtonAI item in StackPanelAIX.Children)
            {
                if (item.IsChecked == true)
                {
                    gameAIX = GameAIFactory.GetGameAI(item.AIType, gameBoard);
                    break;
                }
            }
        }

        private void SetGameAIO()
        {
            foreach (RadioButtonAI item in StackPanelAIO.Children)
            {
                if (item.IsChecked == true)
                {
                    gameAIO = GameAIFactory.GetGameAI(item.AIType, gameBoard);
                    break;
                }
            }
        }

        void AnnounceWinner(TicTacToeResult winner)
        {
            if (winner == TicTacToeResult.Player_X)
            {
                TextBlockResult.Text = "Az X játékos nyert!";
            }
            else if (winner == TicTacToeResult.Player_O)
            {
                TextBlockResult.Text = "Az O játékos nyert!";
            }
            else if (winner == TicTacToeResult.Draw)
            {
                TextBlockResult.Text = "Döntetlen!";
            }
        }

        void NextMove(GameAIAbstract gameAI, TicTacToeSign sign)
        {
            int row;
            int column;

            stopWatch.Restart();

            if (gameAI.GetNextMove(sign, out row, out column))
            {
                stopWatch.Stop();

                TextBlockAITime.Text = stopWatch.ElapsedMilliseconds.ToString() + " ms";

                if (gameAI is IGameAIMinimax)
                {
                    TextBlockAISteps.Text = gameAI.Steps.ToString();

                    int bestResult = (gameAI as IGameAIMinimax).GetBestResult();
                    string bestText;

                    switch (bestResult)
                    {
                        case -1:
                            bestText = "A gépi játékos veszíteni fog";
                            break;

                        case 0:
                            bestText = "A gépi játékos döntetlent ér el";
                            break;

                        case 1:
                            bestText = "A gépi játékos győzni fog";
                            break;

                        default:
                            bestText = "???";
                            break;
                    }

                    TextBlockAIBestResult.Text = bestText;
                }

                playingBoard.SetSign(row, column, sign);
                gameBoard.SetSign(row, column, sign);

                TicTacToeResult winner = gameBoard.Winner();

                if (winner != TicTacToeResult.None)
                {
                    AnnounceWinner(winner);
                }
            }
            else
            {
                MessageBox.Show("Nincs következő lépés...");
            }
        }

        void board_BoardClick(object sender, BoardClickEventArgs e)
        {
            if (gameBoard.Winner() != TicTacToeResult.None)
                return;

            if (gameBoard.CorrectMove(e.Row, e.Column))
            {
                playingBoard.SetSign(e.Row, e.Column, playerSign);
                gameBoard.SetSign(e.Row, e.Column, playerSign);

                TicTacToeResult winner = gameBoard.Winner();

                if (winner != TicTacToeResult.None)
                {
                    AnnounceWinner(winner);
                }
                else
                {
                    if (playerSign == TicTacToeSign.Sign_X)
                        NextMove(gameAIO, TicTacToeSign.Sign_O);
                    else
                        NextMove(gameAIX, TicTacToeSign.Sign_X);
                }
            }
        }

        private void NewGame()
        {
            gameBoard.Reset();
            playingBoard.Reset();

            CreateAI();

            TextBlockAITime.Text = "";
            TextBlockAISteps.Text = "";
            TextBlockAIBestResult.Text = "";
            TextBlockResult.Text = "";

            if (gameAIX != null)
            {
                playerSign = TicTacToeSign.Sign_O;
                NextMove(gameAIX, TicTacToeSign.Sign_X);
            }
            else
            {
                playerSign = TicTacToeSign.Sign_X;
            }
        }

        private void Simulation()
        {
            gameBoard.Reset();
            playingBoard.Reset();

            SetGameAIX();
            SetGameAIO();

            int row;
            int column;

            TicTacToeResult winner = TicTacToeResult.None;

            while (winner == TicTacToeResult.None)
            {
                gameAIX.GetNextMove(TicTacToeSign.Sign_X, out row, out column);

                playingBoard.SetSign(row, column, TicTacToeSign.Sign_X);
                gameBoard.SetSign(row, column, TicTacToeSign.Sign_X);

                winner = gameBoard.Winner();

                if (winner == TicTacToeResult.None)
                {
                    gameAIO.GetNextMove(TicTacToeSign.Sign_O, out row, out column);

                    playingBoard.SetSign(row, column, TicTacToeSign.Sign_O);
                    gameBoard.SetSign(row, column, TicTacToeSign.Sign_O);

                    winner = gameBoard.Winner();
                }
            }

            AnnounceWinner(winner);
        }

        private void ButtonNewGame_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonXStrategy1.IsChecked == true && RadioButtonOStrategy1.IsChecked == true)
            {
                MessageBoxGame.MsgWarning("Nem lehet mindkét szereplő emberi játékos!");
                return;
            }

            if (RadioButtonXStrategy1.IsChecked == false && RadioButtonOStrategy1.IsChecked == false)
            {
                MessageBoxGame.MsgWarning("Új játékhoz legalább egy emberi játékos szükséges!");
                return;
            }

            NewGame();
        }

        private void ButtonSimulation_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonXStrategy1.IsChecked == true || RadioButtonOStrategy1.IsChecked == true)
            {
                MessageBoxGame.MsgWarning("Szimulációt csak gépi ellenfelekkel lehet futtatni!");
                return;
            }

            TextBlockAITime.Text = "";
            TextBlockAISteps.Text = "";
            TextBlockAIBestResult.Text = "";
            TextBlockResult.Text = "";

            Simulation();
        }
    }
}
