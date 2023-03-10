using PizdilovoGame.Rassi;
using System;

namespace PizdilovoGame.GameLogic
{
    internal class WritingInfoInConsole
    {

        public void PlayerInfo(IPlayer player1, IPlayer player2)
        {
            var playerNames = $"{player1.Name}  |{player2.Name}";
            var playerHp = $"{player1.HP} HP  |{player2.HP} HP";
            var playerMana = $"{player1.Stamina} Mana  |{player2.Stamina} Mana";
            Console.SetCursorPosition((Console.WindowWidth) - playerMana.Length, 0);
            Console.WriteLine(playerNames);
            Console.SetCursorPosition((Console.WindowWidth) - playerMana.Length, 1);
            Console.WriteLine(playerHp);
            Console.SetCursorPosition((Console.WindowWidth) - playerMana.Length, 2);
            Console.WriteLine(playerMana);
        }
    }
}
