using PizdilovoGame.Buffs;
using System;

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

        public static void ShowBuffInfo(IBuffs buff)
        {
            Console.WriteLine(buff.Description);
        }
    }
}
