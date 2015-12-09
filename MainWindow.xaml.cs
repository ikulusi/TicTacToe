using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;

namespace ticTacToe
{
    public class Matrix
    {
        int[,] matrix = new int[3, 3];

        public Matrix() 
        {
            Reset();
        }

        public bool IsRowFull(int i)
        {
            if (matrix[i, 0] == matrix[i, 1] && matrix[i, 0] == matrix[i, 2] && matrix[i, 0] != 0) return true;
            else return false;
        }

        public void Reset()
        {
            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    matrix[i, j] = 0;
        }

        public bool IsColumnFull(int i)
        {
            if (matrix[0, i] == matrix[1, i] && matrix[0, i] == matrix[2, i] && matrix[0, i] != 0) return true;
            else return false;
        }

        public bool IsDiagonalFull()
        {
            if ((matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2] && matrix[0, 0] != 0) ||
                (matrix[0, 2] == matrix[1, 1] && matrix[1, 1] == matrix[2, 0] && matrix[1, 1] != 0))

                return true;
            else return false;
        }

        public bool IsWin(int i, int j)
        {
            if (IsColumnFull(j) || IsRowFull(i) || IsDiagonalFull()) return true;
            else return false;
        }

        public int element(int i, int j)
        {
            return matrix[i, j];
        }

        public void set (int i, int j, string player )
        {
            if (player == "o") matrix[i, j] = 1;
            else matrix[i, j] = 2;
        }

        public bool HasSomebodyWon()
        {
            for (int i = 0; i < 2; ++i)
                for (int j = 0; j < 2; ++j)
                    if (IsWin(i, j)) return true;
            return false;
        }
    }


    public class Player
    {
        int player;

        public Player()
        {
            player = 0;
        }

        public void Reset()
        {
            player = 0;
        }

        public void ChangePlayer()
        {
            player += 1;
            player %= 2;
        }

        public string Who()
        {
            if (player == 0) return "o";
            else return "x";
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Matrix m = new Matrix();
        Player p = new Player();
        Brush Color;
        TextBlock[] ArrayOfBlocks = null; 

        public MainWindow()
        {
            InitializeComponent();
            ArrayOfBlocks = new[] {textblock1_1, textblock1_2, textblock1_3,
                                    textblock2_1, textblock2_2, textblock2_3,
                                    textblock3_1, textblock3_2, textblock3_3};


        }

        private void MouseLeftButtonDownFor_i_j(int i, int j)
        {
            if (m.element(i, j) == 0 && !m.HasSomebodyWon())
            {
                m.set(i, j, p.Who());
                ArrayOfBlocks[3*i + j].Text = p.Who();
                
                Color = textblock1_1.Background;

                if (m.IsWin(i, j))
                {
                    ArrayOfBlocks[3*i + j].Background = Brushes.Yellow;
                }

                p.ChangePlayer();
            }
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            p.Reset();
            m.Reset();

            foreach(var x in ArrayOfBlocks )
            {
                x.Text = ""; x.Background = Color;
            }
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
    }
}
