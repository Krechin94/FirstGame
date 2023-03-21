using PizdilovoGame.Rassi;

namespace PizdilovoGame.Buffs
{
    internal class ManaRestoring : IBuffs
    {
        public string Name { get; } = "Mana Restoring";

        public int Cost { get; } = 3;

        public string Affiliations { get; } = "All";

        public void Activate(IPlayer player1, IPlayer player2)
        {
           player1.Mana -= Cost;
           player1.Mana += Cost * 2;
        }
    }
}
