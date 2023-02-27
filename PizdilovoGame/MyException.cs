using System;


namespace PizdilovoGame
{
    public class WrongUserInputException:Exception
    {
        public WrongUserInputException() : base("Пожалуйста введи число от 1 до 3 \n Не надо вводить буквы" )
        { 

        }
    }
}
