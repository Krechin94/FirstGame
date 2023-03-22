using PizdilovoGame.Buffs;
using PizdilovoGame.Rassi;
using System;
using System.Threading;

namespace PizdilovoGame.GameLogic
{
    internal static class WritingInConsole
    {
        public static void SayingHelloInConsole()
        {
            Console.WriteLine("Добро пожаловать в игру\nСуть игры дать другому по ебалу");
        }

        public static void TextWithChoosingRassi()
        {
            Console.WriteLine("Выберите персонажа \n Elf - 1 \n Ork -2 \n Human - 3");
        }

        public static void TakingWeaponText()
        {
            Console.WriteLine("Выберите оружие \n Axe - 1 \n Sword -2 \n Shield - 3");
        }

        public static void StartingFightText()
        {
            Console.WriteLine("Драка Начинается\nКто проиграет тот лох");
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void WhoPunchWhereToPunchText(string Name)
        {
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"Сейчас очередь {Name}");
            Console.WriteLine("Куда бить 1 - голова, 2 - туловище, 3 - ноги");
        }

        public static void DamageYouInflictText(int uron)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($" ты наносишь {uron} урона");
        }

        public static void SuperComboText(int hp)
        {
            Console.WriteLine($"Тебе повезло, ты открыл супер удар, поэтому тебе восстанавливается {hp * 4} здоровья");
            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void BuffsListText(IBuffs buffs, int nomer)
        {
            string text = $"Заклинание номер - {nomer + 1} {buffs.Name}\n";
            Console.SetCursorPosition((Console.WindowWidth) - text.Length, 4 + nomer);
            Console.WriteLine(text);
        }

        public static void WhoPunchWhatBuffUseText(string Name, int count)
        {
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"Сейчас очередь {Name}");
            Console.WriteLine($"Выбери бафф, введи число от 1 до {count}");
        }

        public static void WhoWinText(IPlayer player)
        {
            Console.WriteLine($"Выиграл {player} c {player.HP} хп");
        }

        public static void MessageWithExceptionBeforCloseProgram()
        {
            Console.WriteLine($"Произошло что-то непредвиденное и программа дальше работать не будет. Смотрите логи в папке {Environment.SpecialFolder.ApplicationData}");
        }

        public static void FormatExMessageText()
        {
            Console.WriteLine("Не вводи буквы попробуй ввести еще раз");
        }
    }
}
