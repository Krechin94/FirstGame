using PizdilovoGame.Rassi;

namespace PizdilovoGame.Buffs
{
    internal class HpRestoring : IBuffs
    {
        public string Name { get; } = "HP Restoring";
        public int Cost { get; } = 3;

        public string Affiliations { get; } = "All";

        public void Activate(IPlayer player1, IPlayer player2)
        {
            player1.HP = player1.HP + 10; 
            player1.Mana = player1.Mana - Cost;
        }
    }
}
