using PizdilovoGame.Rassi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizdilovoGame.Buffs
{
    internal class LightlyWisp : IBuffs
    {
        public string Name { get; } = "LightlyWisp";
        public int Cost { get; } = 6;

        public string Affiliations { get; } = "Elf";

        public void Activate(IPlayer player1, IPlayer player2)
        {
            player1.Mana = player1.Mana - Cost;
            player2.HP = player2.HP - 10;
            player2.Mana = player2.Mana - 3;
        }
    }
}
