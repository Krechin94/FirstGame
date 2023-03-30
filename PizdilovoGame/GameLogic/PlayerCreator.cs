using PizdilovoGame.Rassi;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PizdilovoGame.GameLogic
{
    internal class PlayerCreator
    {
        VvodChisla vvodChisla = new VvodChisla();
        bool saveOrCreate = false;
        public Player CreatingOrDownloadingPlayer(List<Player> listOfPlayersFromFile)
        {
            Console.WriteLine("Введите имя");
            string _name = Console.ReadLine();
            Player player = new Player();
            foreach (Player p in listOfPlayersFromFile)
            {
                if (p.Name == _name)
                {
                    Console.WriteLine($"персонаж под ником {_name} загружается...");
                    Thread.Sleep(2000);
                    player = p;
                    saveOrCreate = true;
                }

            }
            if (saveOrCreate == false)
            {
                Console.WriteLine("Выберите персонажа \n Elf - 1 \n Ork -2 \n Human - 3");
                vvodChisla.Vvod(3);
                int nomer = vvodChisla.number;
                {
                    switch (nomer)
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
