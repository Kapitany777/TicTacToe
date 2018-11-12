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
    /// Interaction logic for UserControlBoard.xaml
    /// </summary>
    public partial class UserControlBoard : UserControl
    {
        public event EventHandler<BoardClickEventArgs> BoardClick;
        
        UserControlField[,] fields;

        private void AddFields()
        {
            fields = new UserControlField[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    UserControlField field = new UserControlField();

                    field.Row = i;
                    field.Column = j;
                    field.SetSign(TicTacToeSign.Empty);

                    field.SetValue(Grid.RowProperty, i);
                    field.SetValue(Grid.ColumnProperty, j);

                    field.MouseDown += field_MouseDown;
                    
                    GridBoard.Children.Add(field);

                    fields[i, j] = field;
                }
            }
        }
        
        public void Reset()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    fields[i, j].SetSign(TicTacToeSign.Empty);
                }
            }
        }

        void field_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (BoardClick != null)
            {
                UserControlField field = sender as UserControlField;

                BoardClick(this, new BoardClickEventArgs(field.Row, field.Column));
            }
        }

        public void SetSign(int row, int column, TicTacToeSign sign)
        {
            fields[row, column].SetSign(sign);
        }

        public UserControlBoard()
        {
            InitializeComponent();

            AddFields();
        }
    }
}
