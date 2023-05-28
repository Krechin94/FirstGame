using PizdilovoGame.Rassi;
using PizdilovoGame.Weapons;
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

        public Player CreatingOrDownloadingPlayer()
        {
            Player player = new Player();
            Console.WriteLine("Введите имя");
            string _name = Console.ReadLine();
            if (File.Exists($"{WorkWithFileLogic.PathToGameSaveData}\\{_name}.json"))
            {
                var textPerson = File.ReadAllText($"{WorkWithFileLogic.PathToGameSaveData}\\{_name}.json");
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

        List<IWeapon> weapons = new List<IWeapon>
        {
            new BloodyAxe(),
            new LeftHandElfSword(),
            new RightHandElfSword(),
            new TurtuleShield(),
            new TurtuleSword(),
        };

        public void Equip(IWeapon weapon, List<IWeapon> weapons)
        {
            int i = 0;
            Console.WriteLine("Выбери оружие которое хочешь надеть");
            foreach (IWeapon oruzhie in weapons)
            {
                Console.SetCursorPosition(0, 1 + i);
                Console.WriteLine($"{i+1} - {oruzhie.Name} : {oruzhie.Description}");
            }
            int count = weapons.Count;
            Console.WriteLine($"Vvedi Chislo ot 1 do {count}");
            _vvodChisla.Vvod(count);
            int chislo = _vvodChisla.number;
            weapons[chislo - 1] = weapon;
        }
    }
}
