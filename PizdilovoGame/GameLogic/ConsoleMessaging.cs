using PizdilovoGame.Buffs;
using System;

namespace PizdilovoGame.GameLogic
{
    internal static class ConsoleMessaging
    {
        public static void ShowMessage(string message )
        {
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
