using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using ticTacToe.Logic;

namespace ticTacToe.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void NewPlayerIsAlwaysFirstPlayer()
        {
            var player = new Player();

            Assert.AreEqual(PlayerType.First, player.Who());
        }
    }
}
