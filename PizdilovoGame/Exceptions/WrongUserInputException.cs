using System;


namespace PizdilovoGame.Exceptions
{
    public class WrongUserInputException : Exception
    {
        public WrongUserInputException(int maxNumber) : base($"Пожалуйста введи число от 1 до {maxNumber}")
        {

        }
    }
}
