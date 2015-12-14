using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using ticTacToe.Logic;

namespace ticTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Logic.Matrix m = new Logic.Matrix();
        Player p = new Player();
        Brush Color;
        Cell[] ArrayOfBlocks = null;


        public MainWindow()
        {
            InitializeComponent();
            ArrayOfBlocks = new[] {textblock1_1, textblock1_2, textblock1_3,
                                    textblock2_1, textblock2_2, textblock2_3,
                                    textblock3_1, textblock3_2, textblock3_3};
            textBox.Text = "Na redu je: " + p.WhoString().ToUpper();

        }

        private void MouseLeftButtonDownFor_i_j(int i, int j)
        {
            if (m.element(i, j) == 0 && !m.HasSomebodyWon())
            {
                m.set(i, j, p.WhoString());
                ArrayOfBlocks[3 * i + j].CurrentPlayer = p.Who();

                Color = textblock1_1.Background;

                if (m.IsWin(i, j))
                {
                    ArrayOfBlocks[3 * i + j].Background = Brushes.Yellow;
                    textBox.Text = "Pobijedio je: " + p.WhoString().ToUpper();
                    return;
                }

                p.ChangePlayer();
                textBox.Text = "Na redu je: " + p.WhoString().ToUpper();
            }
        }

        private void Reset()
        {
            p.Reset();
            m.Reset();
            textBox.Text = "Na redu je: " + p.WhoString().ToUpper();

            foreach (var x in ArrayOfBlocks)
            {
                x.CurrentPlayer = PlayerType.None; x.Background = Color;
            }
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Reset();
        }


        private void textblock1_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseLeftButtonDownFor_i_j(0, 0);
        }



        private void textblock1_2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseLeftButtonDownFor_i_j(0, 1);
        }

        private void textblock1_3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseLeftButtonDownFor_i_j(0, 2);
        }

        private void textblock2_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseLeftButtonDownFor_i_j(1, 0);
        }

        private void textblock2_2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseLeftButtonDownFor_i_j(1, 1);
        }

        private void textblock2_3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseLeftButtonDownFor_i_j(1, 2);
        }

        private void textblock3_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseLeftButtonDownFor_i_j(2, 0);
        }

        private void textblock3_2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseLeftButtonDownFor_i_j(2, 1);
        }

        private void textblock3_3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseLeftButtonDownFor_i_j(2, 2);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
    }
}
