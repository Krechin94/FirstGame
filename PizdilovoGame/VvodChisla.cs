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
            try
            {
                Chislo = int.Parse(Console.ReadLine());
                if (Chislo != 1 && Chislo != 2 && Chislo != 3)
                {
                    throw new WrongUserInputException();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message + "вводи от 1 до 4");
            }
            Number = Chislo;
        }
       
    }
}
