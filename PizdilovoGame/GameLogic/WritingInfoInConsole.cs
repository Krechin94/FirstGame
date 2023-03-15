using PizdilovoGame.Rassi;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizdilovoGame.GameLogic
{
    internal class WritingInfoInConsole
    {
        int raznitsahp;
        int raznitsaName;
        int raznitsaMana;

        public void PlayerInfo(IPlayer player1, IPlayer player2)
        {
            var playerName1 = $"{player1.Name}";
            var playerName2 = $"{player2.Name}";
            var playerHp1 = $"{player1.HP} HP";
            var playerHp2 = $"{player2.HP} HP";
            var playerMana1 = $"{player1.Stamina} Mana";
            var playerMana2 = $"{player2.Stamina} Mana";

            var displayInfoLengths = new List<int>
            {
                playerName1.Length,
                playerName2.Length,
                playerHp1.Length,
                playerHp2.Length,
                playerMana1.Length,
                playerMana2.Length,
            };

            displayInfoLengths.Sort();
            var longest = displayInfoLengths.Last();

            raznitsaName = longest - playerName1.Length;
            raznitsahp = longest - playerHp1.Length;
            raznitsaMana = longest - playerMana1.Length;
            playerName1 = Viravnivanie(raznitsaName, playerName1);
            playerHp1 = Viravnivanie(raznitsahp, playerHp1);
            playerMana1 = Viravnivanie(raznitsaMana, playerMana1);

            Console.SetCursorPosition((Console.WindowWidth) - longest * 3, 0);
            Console.WriteLine($"{playerName1} |{playerName2}");
            Console.SetCursorPosition((Console.WindowWidth) - longest * 3, 1);
            Console.WriteLine($"{playerHp1} |{playerHp2}");
            Console.SetCursorPosition((Console.WindowWidth) - longest * 3, 2);
            Console.WriteLine($"{playerMana1} |{playerMana2}");
            Console.SetCursorPosition(0, 0);
        }

        private string Viravnivanie(int raznitsaDlini, string text)
        {
            for (int i = 0; i < raznitsaDlini; i++)
            {
                text += " ";
            }
            return text;
        }
    }
}
