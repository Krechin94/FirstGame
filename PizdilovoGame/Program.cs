﻿using PizdilovoGame.Weapons;
using PizdilovoGame.Rassi;
using System;
using PizdilovoGame.GameLogic;

namespace PizdilovoGame
{
    internal class Program
    {
        static Random random = new Random();
        static IPlayer[] _players;

        static void Main(string[] args)             
        {
            WorkWithFileLogic workWithFileLogic = new WorkWithFileLogic();
            WritingInfoInConsole writingInfoInConsole = new WritingInfoInConsole();
            PlayerCreator choosingRassaNameWeaponLogic = new PlayerCreator();

            workWithFileLogic.CheckingAndCreatingDirectory();
            try
            {
                Console.WriteLine("Добро пожаловать в игру");
                Console.WriteLine("Суть игры дать другому по ебалу");

                int kolichestvo;
                kolichestvo = 2;
                _players = new IPlayer[kolichestvo];
                VvodChisla vvodChisla = new VvodChisla();                
                for (int i = 0; i < kolichestvo; i++)
                {
                    Console.WriteLine("Выберите персонажа \n Elf - 1 \n Ork -2 \n Human - 3");
                    vvodChisla.Vvod(3);
                    int personazh = vvodChisla.number;
                    _players[i] = choosingRassaNameWeaponLogic.SozdaniePersonozha(personazh);
                    _players[i].Equip(ChooseWeapon());
                    Console.Clear();
                }

                var playerManager = new PlayerInfoManager(_players[0], _players[1]);
                foreach (Player player in _players)
                {
                    player.HpAndManaChanged += playerManager.PrintInfo;
                    player.HpAndManaChanged += CheckIfGameEnded;
                    SavingPlayers.ChekingFile(player);
                }

                Console.WriteLine("Драка Начинается");        
                Console.WriteLine("Кто проиграет тот лох");

                int nomer = random.Next(0, kolichestvo);
                IPlayer currentChamp = _players[nomer];
                IPlayer anotherChamp = nomer == 0 ? _players[1] : _players[0];

                do
                {
                    currentChamp.Udar(anotherChamp);
                    anotherChamp.Udar(currentChamp);
                }
                while (currentChamp.HP > 0 && anotherChamp.HP > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошло что-то непредвиденное и программа дальше работать не будет. Смотрите логи в папке {Environment.SpecialFolder.ApplicationData}");
                workWithFileLogic.WritingFile(ex.Message, ex.StackTrace);
                throw;
            }
         }

        private static void CheckIfGameEnded()
        {
            var currentChamp = _players[0];
            var anotherChamp = _players[1];

            if (currentChamp.HP <= 0 || anotherChamp.HP <= 0)
            {
                if (currentChamp.HP > anotherChamp.HP)
                {
                    Console.WriteLine($"Выиграл {currentChamp} c {currentChamp.HP} хп");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine($"Выиграл {anotherChamp} c {anotherChamp.HP} хп");
                    Environment.Exit(0);
                }
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
