using PizdilovoGame.Rassi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace PizdilovoGame.GameLogic
{
    internal class PlayerCreator
    {
        VvodChisla _vvodChisla = new VvodChisla();
        private static string _pathToAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public Player CreatingOrDownloadingPlayer()
        {
            Player player = new Player();
            Console.WriteLine("Введите имя");
            string _name = Console.ReadLine();
            if (File.Exists($"{WorkWithFileLogic.pathToAppData}\\PizdilovoGame\\Saves\\{_name}.json"))
            {
                var textPerson = File.ReadAllText($"{_pathToAppData}\\PizdilovoGame\\Saves\\{_name}.json");
                Player deserializedPerson = JsonSerializer.Deserialize<Player>(textPerson);
                Console.WriteLine($"персонаж под ником {_name} загружается...");
                Thread.Sleep(2000);
                player = deserializedPerson;
                player.HP = 100;
                player.Mana = 0;
            }
            else
            {
                Console.WriteLine("Выберите персонажа \n Elf - 1 \n Ork -2 \n Human - 3");
                _vvodChisla.Vvod(3);
                int _nomer = _vvodChisla.number;
                {
                    switch (_nomer)
                    {
                        case 1:
                            {
                                player = new Elf();
                                player.Name = _name;
                                break;
                            }
                        case 2:
                            {
                                player = new Ork();
                                player.Name = _name;
                                break;
                            }
                        case 3:
                            {
                                player = new Human();
                                player.Name = _name;
                                break;
                            }
                    }
                }
            }
            return player;
        }
    }
}
