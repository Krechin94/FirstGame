using PizdilovoGame.Rassi;

namespace PizdilovoGame.Buffs
{
    internal class SpitIntoTheFace : IBuffs
    {
        public string Name { get; } = "SpitIntoTheFace";

        public int Cost { get; } = 6;

        public string Affiliations { get; } = "Ork";

        public void Activate(IPlayer player1, IPlayer player2)
        {
            player1.Mana -= Cost;
            player2.HP -= 15;
        }
    }
}
