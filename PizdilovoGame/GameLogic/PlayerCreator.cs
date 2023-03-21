using PizdilovoGame.Rassi;
using System;

namespace PizdilovoGame.GameLogic
{
    internal class PlayerCreator
    {
        public IPlayer SozdaniePersonozha(int nomer)
        {
            IPlayer rasa = null;
            switch (nomer)
            {
                case 1:
                    {
                        rasa = new Elf();
                        Console.WriteLine("Введите имя");
                        rasa.Name = Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        rasa = new Ork();
                        Console.WriteLine("Введите имя");
                        rasa.Name = Console.ReadLine();
                        break;
                    }
                case 3:
                    {
                        rasa = new Human();
                        Console.WriteLine("Введите имя");
                        rasa.Name = Console.ReadLine();
                        break;
                    }
            }
            return rasa;
        }
    }
}
