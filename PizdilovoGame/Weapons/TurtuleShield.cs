using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizdilovoGame.Weapons
{
    internal class TurtuleShield : IWeapon
    {
        public string Name { get; set; } = "TurtuleShield";
        public string Description { get; set; } = "Left hand shield that can defend you, from your opponent";

        public int Uron { get; } = 3;

        public int Cost { get; } = 1;

        public string Affiliation { get; set; } = "Ork";
    }
}
