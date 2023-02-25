using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizdilovoGame.Weapons;

namespace PizdilovoGame.Rassi
{
    public class Human : Player
    {
        public Human()
        {
            HP = 100;
            Stamina = 100;
            Nation = "Human";
        }
    }
}
