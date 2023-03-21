using PizdilovoGame.Rassi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizdilovoGame.Buffs
{
    internal class WetWilly : IBuffs
    {
        public string Name { get; } = "WetWilly";

        public int Cost { get; } = 6;
        public string Affiliations { get; } = "Human";

        public void Activate(IPlayer player1, IPlayer player2)
        {
            player1.Mana -= Cost / 2;
            player2.HP -= 10;
        }
    }
}
