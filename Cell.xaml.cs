using System.Windows.Controls;
using ticTacToe.Logic;

namespace ticTacToe
{
    /// <summary>
    /// Interaction logic for Cell.xaml
    /// </summary>
    public partial class Cell : UserControl
    {
        private PlayerType currentPlayer;
        public PlayerType CurrentPlayer
        {
            set
            {
                this.currentPlayer = value;
                if (value == PlayerType.First)
                    TextHolder.Text = "o";
                else if (value == PlayerType.Second)
                    TextHolder.Text = "x";
                else if (value == PlayerType.None)
                    TextHolder.Text = string.Empty;
            }
        }

        public Cell()
        {
            InitializeComponent();
        }
    }
}
