using PizdilovoGame.Rassi;
using System.IO;
using System.Text.Json;

namespace PizdilovoGame.GameLogic
{
    internal static class SavingPlayers
    {

        public static void Serealization(IPlayer player)
        {
            var serializedPerson = JsonSerializer.Serialize(player);
            File.WriteAllText($"{WorkWithFileLogic.PathToGameSaveData}\\{player.Name}.json", serializedPerson);
        }
    }
}
