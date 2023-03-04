using System;
using System.IO;

namespace PizdilovoGame
{
    internal class VvodChisla
    {
        public int Chislo;
        public int Number;
        public void Vvod()
        {
            do
            {
               DateTime dateTime = DateTime.Now;
                try
                {
                    Chislo = int.Parse(Console.ReadLine());
                   if (Chislo != 1 && Chislo != 2 && Chislo != 2)
                    {
                        throw new WrongUserInputException();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Не вводи буквы попробуй ввести еще раз");
                    string pathToAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    using (var sw = new StreamWriter($"{pathToAppData}\\Log.txt", true))
                    {
                        sw.WriteLine("ошибка нахуй");
                        sw.WriteLine(dateTime);
                        sw.WriteLine(ex.Message);
                    }
                }
                catch (WrongUserInputException wuie)
                {
                    Console.WriteLine(wuie.Message + "\nПопробуй ввести еще раз");
                    string pathToAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    using (var sw = new StreamWriter($"{pathToAppData}\\Log.txt", true))
                    {
                        sw.WriteLine("ошибка нахуй");
                        sw.WriteLine(dateTime);
                        sw.WriteLine(wuie.Message);
                    }
                }

            }
            while (Chislo != 1 && Chislo != 2 && Chislo != 3);

             Number = Chislo;
        }
       
    }
}
