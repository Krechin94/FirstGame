using System;


namespace PizdilovoGame.Exceptions
{
    public class WrongUserInputException : Exception
    {
        public WrongUserInputException() : base("Пожалуйста введи число от 1 до 3")
        {

        }

    }
}
