﻿using System;
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
                }
                catch (WrongUserInputException wuie)
                {
                    Console.WriteLine(wuie.Message + " Попробуй ввести еще раз");
                }

            }
            while (Chislo != 1 && Chislo != 2 && Chislo != 3);

             Number = Chislo;
        }
       
    }
}
