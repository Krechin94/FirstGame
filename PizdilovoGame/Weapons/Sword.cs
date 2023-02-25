using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizdilovoGame.Weapons
{
    public class Sword : IWeapon
    {
        public string Name { get; } = "Sword";

        public int Uron { get; } = 10;

        public int Cost { get; } = 10;
    }
}
