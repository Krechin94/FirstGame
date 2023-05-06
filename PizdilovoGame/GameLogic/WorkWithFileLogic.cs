using System;
using System.IO;

namespace PizdilovoGame.GameLogic
{
    internal class WorkWithFileLogic
    {
        public static string PathToGameData = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\PizdilovoGame";
        public static string PathToGameSaveData = $"{PathToGameData}\\Saves";
        public static void WritingFile(string exceptionMessage, string placeOfException)
        {
            using (var sw = new StreamWriter($"{PathToGameData}\\Log.txt", true))
            {
                sw.WriteLine("ошибка нахуй");
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(exceptionMessage + "\n" + placeOfException);
            }
        }

        public static void CheckingAndCreatingDirectory()
        {
            if (!Directory.Exists($"{PathToGameData}"))
            {
                Directory.CreateDirectory($"{PathToGameData}");
            }
            if (!Directory.Exists($"{PathToGameSaveData}"))
            {
                Directory.CreateDirectory($"{PathToGameSaveData}");
            }
        }
    }
}
