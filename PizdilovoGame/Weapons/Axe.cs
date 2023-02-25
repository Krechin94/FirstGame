using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizdilovoGame.Weapons
{
    internal class Axe : IWeapon
    {
        public string Name { get; } = "Axe";

        public int Uron { get; } = 15;
        public int Cost { get; } = 15;
    }
}
