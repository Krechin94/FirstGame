using PizdilovoGame.Buffs;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PizdilovoGame.GameLogic
{
    internal static class ConsoleMessaging
    {
        public static void ShowBuffMessage(string message, int i)
        {
            ShowMessage(message, (Console.WindowWidth) - message.Length, 4 + i);
        }

        public static void ConsoleClear()
        {
            Console.Clear();    
        }

        public static void StartFightingMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void ShowFightingMessage(string message)
        {
            ShowMessage(message, 0, 1);
        }

        public static void ShowGameInfoCursor00(string message)
        {
            ShowMessage(message, 0, 0);
        }

        public static void ShowMessage(string message,int _xCoordinate=0, int _yCoordinate=0 )
        {
            Console.SetCursorPosition(_xCoordinate, _yCoordinate);
            Console.WriteLine(message);
        }

        public static void SuperUdarMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
        }

        public static void ShowRules()
        {
            Console.Clear();
            Console.WriteLine("");
        }

        public static void ShowWeaponInfo()
        {
            Console.Clear();
            Console.WriteLine("");
        }

        public static void ShowBuffInfo(List<IBuffs> buffs)
        {
            int i = 0;
            foreach (IBuffs buff in buffs)
            {
                Console.SetCursorPosition(0, 7 + i);
                Console.WriteLine(buff.Description);
                i++;
            }
        }
    }
}
