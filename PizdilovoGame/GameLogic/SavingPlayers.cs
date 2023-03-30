using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PizdilovoGame.GameLogic
{
    internal static class SavingPlayers
    {
        private static string _pathToAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static void ChekingFile()
        {
            List<Player> list = new List<Player>();
            if (File.Exists($"{_pathToAppData}\\PizdilovoGame\\person.json") == false)
            {
                var serializedPerson1 = JsonSerializer.Serialize(list);
                File.WriteAllText($"{_pathToAppData}\\PizdilovoGame\\person.json", serializedPerson1);
            }
        }

        public static void Serealization(List<Player> myList)
        {
            var serializedPerson = JsonSerializer.Serialize(myList);
            File.WriteAllText($"{_pathToAppData}\\PizdilovoGame\\person.json", serializedPerson);
        }

        public static List<Player> Deserialization()
        {
            var textPerson = File.ReadAllText($"{_pathToAppData}\\PizdilovoGame\\person.json");
            List<Player> deserializedPerson = JsonSerializer.Deserialize<List<Player>>(textPerson);
            return deserializedPerson;
        }
    }
}
