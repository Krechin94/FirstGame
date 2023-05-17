using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizdilovoGame.Weapons
{
    internal class BloodyAxe : IWeapon
    {
        public string Name { get; set; } = "BloodyAxe";
        public string Description { get; set; } = "Double hand axe, which can scare your opponent";

        public int Uron { get; } = 10;

        public int Cost { get; } = 2;

        public string Affiliation { get; set; } = "Human";
    }
}
