namespace ticTacToe.Logic
{
    public enum PlayerType
    {
        None,
        First,
        Second
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

        public PlayerType Who()
        {
            if (player == 0) return PlayerType.First;
            else return PlayerType.Second;
        }

        public string WhoString()
        {
            if (player == 0) return "o";
            else return "x";
        }
    }
}
