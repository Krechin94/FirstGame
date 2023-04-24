using PizdilovoGame.Weapons;
using PizdilovoGame.Rassi;
using System;
using PizdilovoGame.GameLogic;
using System.Collections.Generic;

namespace PizdilovoGame
{
    internal class Program
    {
        static Random random = new Random();
        static IPlayer[] _players;

        static void Main(string[] args)             
        {
            WritingInfoInConsole writingInfoInConsole = new WritingInfoInConsole();
            PlayerCreator choosingRassaNameWeaponLogic = new PlayerCreator();

            WorkWithFileLogic.CheckingAndCreatingDirectory();
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
                    var player = choosingRassaNameWeaponLogic.CreatingOrDownloadingPlayer();
                    player.Equip(ChooseWeapon());
                    _players[i] = player;
                    Console.Clear();
                }

                List<Player> listofPlayers = new List<Player>();
                var playerManager = new PlayerInfoManager(_players[0], _players[1]);
                foreach (Player player in _players)
                {
                    player.HpAndManaChanged += playerManager.PrintInfo;
                    player.HpAndManaChanged += CheckIfGameEnded;
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

                SavingPlayers.Serealization(anotherChamp);
                SavingPlayers.Serealization(currentChamp);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошло что-то непредвиденное и программа дальше работать не будет. Смотрите логи в папке {Environment.SpecialFolder.ApplicationData}");
                WorkWithFileLogic.WritingFile(ex.Message, ex.StackTrace);
                
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
                }
                else
                {
                    Console.WriteLine($"Выиграл {anotherChamp} c {anotherChamp.HP} хп");
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
