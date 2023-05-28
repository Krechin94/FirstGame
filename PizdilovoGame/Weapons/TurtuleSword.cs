﻿using PizdilovoGame.Rassi;

namespace PizdilovoGame.Weapons
{
    internal class TurtuleSword : IWeapon
    {
        public string Name { get; set; } = "TurtuleSword";
        public string Description { get; set; } = "Short right hand sword, best use with TurtuleShield";

        public int Uron { get; } = 5;

        public int Cost { get; } = 1;

        public string Affiliation { get; set; } = "Ork";

        public void Equip(IPlayer player)
        {
            player.Uron += Uron;
            if (player.Nation == Affiliation)
            {
                player.HP += 10;
                player.ChancetoBlock += 3;
            }
        }
    }
}