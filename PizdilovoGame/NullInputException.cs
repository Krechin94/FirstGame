using System;


namespace PizdilovoGame
{
    public class NullInputException:Exception
    {
        public NullInputException() : base("В имени ничего нет")
        {

        }
    }
}
