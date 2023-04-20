using PizdilovoGame.Rassi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PizdilovoGame.GameLogic
{
    internal static class SavingPlayers
    {
        private static string _pathToAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static void Serealization(IPlayer player)
        {
            player.HP = 10;
            player.Mana = 0;
            var serializedPerson = JsonSerializer.Serialize(player);
            File.WriteAllText($"{_pathToAppData}\\PizdilovoGame\\Saves\\{player.Name}.json", serializedPerson);
        }
    }
}
