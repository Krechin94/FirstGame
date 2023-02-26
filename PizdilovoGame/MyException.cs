using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizdilovoGame
{
    internal class MyException:Exception
    {
        public MyException() : base("Пожалуйста введи число от 1 до 3Не надо вводить буквы" )
        { }
    }
}
