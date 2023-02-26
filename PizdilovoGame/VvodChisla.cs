using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizdilovoGame
{
    internal class VvodChisla
    {
        public int chislo;
        public int vvod;
        public void Vvod()
        {
         chislo = int.Parse(Console.ReadLine());
          if (chislo != 1 && chislo != 2 && chislo !=3 )
              throw new MyException();
            vvod = chislo;
        }
       
    }
}
