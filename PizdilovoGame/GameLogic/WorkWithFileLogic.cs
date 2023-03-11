using System;
using System.IO;

namespace PizdilovoGame.GameLogic
{
    internal class WorkWithFileLogic
    {
        public void WritingFile(string exceptionMessage, string placeOfException)
        {
            string pathToAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            using (var sw = new StreamWriter($"{pathToAppData}\\PizdilovoGame\\Log.txt", true))
            {
                sw.WriteLine("ошибка нахуй");
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(exceptionMessage + "\n" + placeOfException);
            }
        }

        public void CheckingAndCreatingDirectory()
        {
            string pathToAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists($"{pathToAppData}\\PizdilovoGame"))
            {
                Directory.CreateDirectory($"{pathToAppData}\\PizdilovoGame");
            }
        }
    }
}
