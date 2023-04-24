using System;
using System.IO;

namespace PizdilovoGame.GameLogic
{
    internal class WorkWithFileLogic
    {
        public static string pathToAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static void WritingFile(string exceptionMessage, string placeOfException)
        {
            using (var sw = new StreamWriter($"{pathToAppData}\\PizdilovoGame\\Log.txt", true))
            {
                sw.WriteLine("ошибка нахуй");
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(exceptionMessage + "\n" + placeOfException);
            }
        }

        public static void CheckingAndCreatingDirectory()
        {
            if (!Directory.Exists($"{pathToAppData}\\PizdilovoGame"))
            {
                Directory.CreateDirectory($"{pathToAppData}\\PizdilovoGame");
            }
            if (!Directory.Exists($"{pathToAppData}\\PizdilovoGame\\Saves"))
            {
                Directory.CreateDirectory($"{pathToAppData}\\PizdilovoGame\\Saves");
            }
        }
    }
}
