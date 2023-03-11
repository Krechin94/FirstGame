using PizdilovoGame.Rassi;
using System;
using System.Linq;
using System.Numerics;

namespace PizdilovoGame.GameLogic
{
    internal class WritingInfoInConsole
    {
        enum DisplayColumn { Left, Right };
        enum DisplayLine { Name, HP, Mana };

        const int MaxInfoStringLength = 8;
        const string Delimiter = "    |    ";

        private int _maximumTableSize;

        public WritingInfoInConsole()
        {
            Initialize();
        }

        private void Initialize()
        {
            // get column count based on DisplayColumn enumeration
            var numberOfColumns = Enum.GetValues<DisplayColumn>().Length;
            var numberOfDelimiters = numberOfColumns - 1;

            _maximumTableSize = MaxInfoStringLength * numberOfColumns + Delimiter.Length * numberOfDelimiters;
        }

        public void PlayerInfo(IPlayer player1, IPlayer player2)
        {
            PrintDelimiters();
            PrintForPlayer(player1, DisplayColumn.Left);
            PrintForPlayer(player2, DisplayColumn.Right);
        }

        private void PrintDelimiters()
        {
            // get column count based on DisplayColumn enumeration
            var numberOfColumns = Enum.GetValues<DisplayColumn>().Length;

            // get line count based on DisplayLine enumeration
            var numberOfLines = Enum.GetValues<DisplayLine>().Length;
            for (var line = 0; line < numberOfLines; line++)
            {
                // start printing from second column
                for (var column = 1; column < numberOfColumns; column++)
                {
                    var delimiter = column - 1;
                    var currentCursorPosition = _maximumTableSize - MaxInfoStringLength * column - delimiter * Delimiter.Length;
                    Console.SetCursorPosition((Console.WindowWidth) - currentCursorPosition, line);
                    Console.WriteLine($"{Delimiter}");
                }
            }

            // reset position for further use
            Console.SetCursorPosition(0, 0);
        }

        private void PrintForPlayer(IPlayer player, DisplayColumn column)
        {
            PrintName(player.Name, column);
            PrintHealth(player.HP, column);
            PrintMana(player.Stamina, column);
        }

        private void PrintName(string playerName, DisplayColumn column)
        {
            PrintCell(DisplayLine.Name, column, playerName);
        }

        private void PrintHealth(int playerHealth, DisplayColumn column)
        {
            PrintCell(DisplayLine.HP, column, $"{playerHealth} HP");
        }

        private void PrintMana(int playerMana, DisplayColumn column)
        {
            PrintCell(DisplayLine.Mana, column, $"{playerMana} Mana");
        }

        private void PrintCell(DisplayLine line, DisplayColumn column, string message)
        {
            var printedMessage = message;

            // crop message if it's too big
            if (printedMessage.Length > MaxInfoStringLength)
            {
                printedMessage = printedMessage.Substring(0, MaxInfoStringLength - 3);
                printedMessage += "...";
            }

            // add spaces if there's room for it
            var spaceCount = (MaxInfoStringLength - printedMessage.Length) % 4;
            for (var i = 0; i < spaceCount; i++)
            {
                printedMessage += '\t';
            }

            var currentCursorPosition = _maximumTableSize - MaxInfoStringLength * (int)column - (int)column * Delimiter.Length;
            Console.SetCursorPosition((Console.WindowWidth) - currentCursorPosition, (int)line);
            Console.WriteLine($"{printedMessage}");

            // reset position for further use
            Console.SetCursorPosition(0, 0);
        }
    }
}
