using System;


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
                Console.WriteLine(exp.Message);
                if (Chislo != 1 && Chislo != 2 && Chislo != 3)
                    throw new WrongUserInputException();
                return;
            }        
            Number = Chislo;
        }
       
    }
}
