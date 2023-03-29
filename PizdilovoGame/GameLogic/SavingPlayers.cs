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
        public static void ChekingFile(Player player) 
        {
            string pathToAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (File.Exists($"{pathToAppData}\\PizdilovoGame\\person.json") == false)
            {
                var mylist = new List<Player>();
                mylist.Add(player);
                var serializedPerson1 = JsonSerializer.Serialize(mylist);
                File.AppendAllText($"{pathToAppData}\\PizdilovoGame\\person.json", serializedPerson1);
            }
            else
            {
                var textPerson = File.ReadAllText($"{pathToAppData}\\PizdilovoGame\\person.json");
                List<Player> deserializedPerson = JsonSerializer.Deserialize<List<Player>>(textPerson);
                foreach (var deserializedPerson2 in deserializedPerson)
                {
                    if (deserializedPerson2.Name == player.Name)
                    {
                        player = deserializedPerson2;
                        Console.WriteLine($"А ты оказывается уже играл-------------Загружаю имя игрока {player.Name}");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        
                        /*var serializedPerson1 = JsonSerializer.Serialize(mylist);
                        File.AppendAllText($"{pathToAppData}\\PizdilovoGame\\person.json", serializedPerson1);*/
                        Console.WriteLine("игрок добавлен в файл");
                    }
                }
                deserializedPerson.Add(player);
                var serializedPerson1 = JsonSerializer.Serialize(deserializedPerson);
                File.AppendAllText($"{pathToAppData}\\PizdilovoGame\\person.json", serializedPerson1);
            }
        }
    }
}
