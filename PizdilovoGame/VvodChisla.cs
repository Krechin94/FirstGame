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
            }
            catch (Exception exp)
            {                
                StreamWriter sw = new StreamWriter("C:\\Users\\79111\\Desktop\\Git\\Log.txt");
                sw.WriteLine(exp.Message);
                Console.WriteLine(exp.Message);
                if (Chislo != 1 && Chislo != 2 && Chislo != 3)
                    throw new WrongUserInputException();
                sw.WriteLine("пошел нахуй");
                return;
            }        
            Number = Chislo;
        }
       
    }
}
