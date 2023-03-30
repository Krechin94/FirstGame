using PizdilovoGame.Rassi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PizdilovoGame.GameLogic
{
    internal static class SavingPlayers
    {
        private static string _pathToAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static void ChekingFile()
        {
            List<Player> list = new List<Player>();
            if (File.Exists($"{_pathToAppData}\\PizdilovoGame\\person11.txt") == false)
            {
                var serializedPerson1 = JsonSerializer.Serialize(list);
                File.WriteAllText($"{_pathToAppData}\\PizdilovoGame\\person11.txt", serializedPerson1);
            }
        }

        public static void Serealization(List<Player> myList)
        {
            var serializedPerson = JsonSerializer.Serialize(myList);
            File.AppendAllText($"{_pathToAppData}\\PizdilovoGame\\person11.txt", serializedPerson);
        }

        public static List<Player> Deserialization()
        {
            var textPerson = File.ReadAllText($"{_pathToAppData}\\PizdilovoGame\\person11.txt");
            List<Player> deserializedPerson = JsonSerializer.Deserialize<List<Player>>(textPerson);
            return deserializedPerson;
        }

        public static void SavingAndLoadingPlayers(Player player)
        {
            List<Player> list = new List<Player>();
            list = Deserialization();
            foreach (Player myPlayer in list)
            {
                if(myPlayer.Name == player.Name)
                {
                    player = myPlayer;
                }
            }
        }
        public static void DeleteFile()
        {
            File.Delete($"{_pathToAppData}\\PizdilovoGame\\person11.txt");
        }
    }
}
