using PizdilovoGame.Weapons;
using PizdilovoGame.Rassi;
using System;
using PizdilovoGame.GameLogic;

namespace PizdilovoGame
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)             
        {
            WorkWithFileLogic workWithFileLogic = new WorkWithFileLogic();
            WritingInfoInConsole writingInfoInConsole = new WritingInfoInConsole();

            workWithFileLogic.CheckingAndCreatingDirectory();
            try
            {
                Console.WriteLine("Добро пожаловать в игру");
                Console.WriteLine("Суть игры дать другому по ебалу");

                int kolichestvo;
                kolichestvo = 2;
                IPlayer[] players = new IPlayer[kolichestvo];
                VvodChisla vvodChisla = new VvodChisla();                
                for (int i = 0; i < kolichestvo; i++)
                {
                    Console.WriteLine("Выберите персонажа \n Elf - 1 \n Ork -2 \n Human - 3");
                    vvodChisla.Vvod(3);                    
                    int personazh = vvodChisla.number;
                                       
                    switch (personazh)
                    {
                        case 1:
                            {
                                IPlayer elf = new Elf();

                                Console.WriteLine("Введите имя");
                                elf.Name = Console.ReadLine();
                                elf.Equip(ChooseWeapon());
                                players[i] = elf;
                                break;
                            }
                        case 2:
                            {
                                IPlayer ork = new Ork();

                                Console.WriteLine("Введите имя");
                                ork.Name = Console.ReadLine();
                                ork.Equip(ChooseWeapon());
                                players[i] = ork;
                                break;
                            }
                        case 3:
                            {
                                IPlayer human = new Human();

                                Console.WriteLine("Введите имя");
                                human.Name = Console.ReadLine();
                                human.Equip(ChooseWeapon());

                                players[i] = human;
                                break;
                            }
                    }

                    Console.Clear();
                }

                var playerManager = new PlayerInfoManager(players[0], players[1]);
                foreach (Player player in players)
                {
                    player.HpAndManaChanged += playerManager.PrintInfo;
                }

                Console.WriteLine("Драка Начинается");        
                Console.WriteLine("Кто проиграет тот лох");

                int nomer = random.Next(0, kolichestvo);
                IPlayer currentChamp = players[nomer];
                IPlayer anotherChamp = nomer == 0 ? players[1] : players[0];

                do
                {
                    currentChamp.Udar(anotherChamp);
                    anotherChamp.Udar(currentChamp);
                }
                while (currentChamp.HP > 0 && anotherChamp.HP > 0);

                if (currentChamp.HP > anotherChamp.HP)
                {
                    Console.WriteLine($"Выиграл {currentChamp} c {currentChamp.HP} хп");
                }
                else
                {
                    Console.WriteLine($"Выиграл {anotherChamp} c {anotherChamp.HP} хп");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошло что-то непредвиденное и программа дальше работать не будет. Смотрите логи в папке {Environment.SpecialFolder.ApplicationData}");
                workWithFileLogic.WritingFile(ex.Message, ex.StackTrace);
                throw;
            }
         }
           public static IWeapon ChooseWeapon()
            {
                Console.WriteLine("Выберите оружие \n Axe - 1 \n Sword -2 \n Shield - 3");
                VvodChisla vvodChisla = new VvodChisla();
                vvodChisla.Vvod(3);

                int personazh = vvodChisla.number;

                IWeapon chosenWeapon;
                switch (personazh)
                {
                    case 1:
                        {
                            chosenWeapon = new Axe();
                            break;
                        }
                    case 2:
                        {
                            chosenWeapon = new Sword();
                            break;
                        }
                    case 3:
                        {
                            chosenWeapon = new Shield();
                            break;
                        }
                    default:
                        {
                            chosenWeapon = null;
                            break;
                        }

                }

                return chosenWeapon;
            }



           


        
    }
}
