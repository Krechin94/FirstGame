using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizdilovoGame.Weapons
{
    internal class Shield : IWeapon
    {
        public string Name { get; } = "Shield";

        public int Uron { get; } = 5;

        public int Cost { get; } = 5;
    }
}
