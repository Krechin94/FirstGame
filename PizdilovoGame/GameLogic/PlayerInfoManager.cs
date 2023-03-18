using PizdilovoGame.Rassi;

namespace PizdilovoGame.GameLogic
{
    internal class PlayerInfoManager
    {
        WritingInfoInConsole _console = new WritingInfoInConsole();
        private IPlayer _player1 { get; }
        private IPlayer _player2 { get; }

        public PlayerInfoManager(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public void PrintInfo()
        {
            _console.PlayerInfo(_player1, _player2);
        }
    }
}
