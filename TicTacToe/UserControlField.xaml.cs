using System;
using System.Collections.Generic;
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
    /// Interaction logic for UserControlField.xaml
    /// </summary>
    public partial class UserControlField : UserControl
    {
        public int Row { get; set; }
        public int Column { get; set; }
        
        public UserControlField()
        {
            InitializeComponent();

            TextBlockSign.Background = new SolidColorBrush(Color.FromArgb(255, 120, 120, 120));
        }

        public void SetSign(TicTacToeSign sign)
        {
            switch (sign)
            {
                case TicTacToeSign.Empty:
                    TextBlockSign.Text = " ";
                    break;
                case TicTacToeSign.Sign_X:
                    TextBlockSign.Text = "X";
                    TextBlockSign.Foreground = new SolidColorBrush(Colors.Black);
                    break;
                case TicTacToeSign.Sign_O:
                    TextBlockSign.Text = "O";
                    TextBlockSign.Foreground = new SolidColorBrush(Colors.Red);
                    break;
                default:
                    break;
            }
        }

        private void TextBlockSign_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlockSign.Background = new SolidColorBrush(Color.FromArgb(255, 170, 170, 170));
        }

        private void TextBlockSign_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlockSign.Background = new SolidColorBrush(Color.FromArgb(255, 120, 120, 120));
        }

        
    }
}
