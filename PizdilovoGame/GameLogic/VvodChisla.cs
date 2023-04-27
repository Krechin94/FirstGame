using PizdilovoGame.Exceptions;
using System;

namespace PizdilovoGame.GameLogic
{
    internal class VvodChisla
    {
        public int chislo;
        public int number;

        WorkWithFileLogic workWithFileLogic = new WorkWithFileLogic();
        public void Vvod(int maxNumber)
        {
            bool qwe = false;
            do
            {
                try
                {
                    chislo = int.Parse(Console.ReadLine());
                    if(chislo <= maxNumber  && chislo >= 0)
                    {
                        qwe = true;
                    }
                    else
                        throw new WrongUserInputException(maxNumber);
                    
                }
                catch (FormatException ex)
                {
                    ConsoleMessaging.ShowMessage("Не вводи буквы попробуй ввести еще раз");
                    workWithFileLogic.WritingFile(ex.Message, ex.StackTrace);
                }
                catch (WrongUserInputException wuie)
                {
                    Console.WriteLine(wuie.Message + "\nПопробуй ввести еще раз");
                    workWithFileLogic.WritingFile(wuie.Message, wuie.StackTrace);
                }
            }
            while (qwe != true);

            number = chislo;
        }

    }
}
