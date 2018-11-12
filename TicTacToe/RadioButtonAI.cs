using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TicTacToeLibrary;

namespace TicTacToe
{
    public class RadioButtonAI : RadioButton
    {
        public GameAIType AIType { get; set; }
    }
}
