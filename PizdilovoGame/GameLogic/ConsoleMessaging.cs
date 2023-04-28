using PizdilovoGame.Buffs;
using System;
using System.Collections.Generic;

namespace PizdilovoGame.GameLogic
{
    internal static class ConsoleMessaging
    {
        public static void ShowInfo(string message)
        {
            ShowMessage(message, 0,5 );
        }

        public static void ShowMessage(string message,int _xCoordinate=0, int _yCoordinate=0 )
        {
            Console.SetCursorPosition(_xCoordinate, _yCoordinate);
            Console.WriteLine(message);
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
