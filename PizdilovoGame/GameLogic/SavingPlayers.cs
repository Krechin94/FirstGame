using PizdilovoGame.Rassi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PizdilovoGame.GameLogic
{
    internal static class SavingPlayers
    {

        public static void Serealization(IPlayer player)
        {
            player.HP = 100;
            player.Mana = 0;
            var serializedPerson = JsonSerializer.Serialize(player);
            File.WriteAllText($"{WorkWithFileLogic.pathToAppData}\\PizdilovoGame\\Saves\\{player.Name}.json", serializedPerson);
        }
    }
}
