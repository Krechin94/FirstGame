using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizdilovoGame.Weapons
{
    internal class TurtuleSword : IWeapon
    {
        public string Name { get; set; } = "TurtuleSword";
        public string Description { get; set; } = "Short right hand sword, best use with TurtuleShield";

        public int Uron { get; } = 5;

        public int Cost { get; } = 1;

        public string Affiliation { get; set; } = "Ork";
    }
}
