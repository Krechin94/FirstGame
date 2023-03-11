using PizdilovoGame.Rassi;
using System;

namespace PizdilovoGame.GameLogic
{
    internal class WritingInfoInConsole
    {
        int longest;
        int raznitsahp;
        int raznitsaName;
        int raznitsaMana;
        string[] arrayProbel = new string[10] { "", " ", "  ", "   ", "    ","     ","      ", "       ", "        ", "         " };
        public void PlayerInfo(IPlayer player1, IPlayer player2)
        {
            var playerName1 = $"{player1.Name}";
            var playerName2 = $"{player2.Name}";
            var playerHp1 = $"{player1.HP} HP";
            var playerHp2 = $"{player2.HP} HP";
            var playerMana1 = $"{player1.Stamina} Mana";
            var playerMana2 = $"{player2.Stamina} Mana";
            if (playerName1.Length > playerHp1.Length)
            {
                if (playerName1.Length > playerMana1.Length)
                {
                    longest = playerName1.Length;
                    raznitsaName = 0;
                    raznitsahp = longest - playerHp1.Length;
                    raznitsaMana = longest - playerMana1.Length;
                }
                else
                {
                    longest = playerMana1.Length;
                    raznitsaName = longest - playerName1.Length;
                    raznitsahp = longest - playerHp1.Length;
                    raznitsaMana = 0;
                }
            }
            else
            {
                if (playerHp1.Length > playerMana1.Length)
                {
                    longest = playerHp1.Length;
                    raznitsaName = longest - playerName1.Length;
                    raznitsahp = 0;
                    raznitsaMana = longest - playerMana1.Length;
                }
                else
                {
                    longest = playerMana1.Length;
                    raznitsaName = longest - playerName1.Length;
                    raznitsahp = longest - playerHp1.Length;
                    raznitsaMana = 0;
                }
            }

            Console.SetCursorPosition((Console.WindowWidth) - longest * 3, 0);
            Console.WriteLine($"{playerName1}{arrayProbel[raznitsaName]} |{playerName2}");
            Console.SetCursorPosition((Console.WindowWidth) - longest * 3, 1);
            Console.WriteLine($"{playerHp1}{arrayProbel[raznitsahp]} |{playerHp2}");
            Console.SetCursorPosition((Console.WindowWidth) - longest * 3, 2);
            Console.WriteLine($"{playerMana1}{arrayProbel[raznitsaMana]} |{playerMana2}");
            Console.SetCursorPosition(0, 0);
        }
    }
}
