using PizdilovoGame.Rassi;

namespace PizdilovoGame.Buffs
{
    internal class HpRestoring : IBuffs
    {
        public string Name { get; } = "HP Restoring";
        public int Cost { get; } = 3;

        public string Affiliations { get; } = "All";
        public string Description { get; } = "Заклинание по восстановлению хп. Восстанавливает 10 хп. Стоит 3 аны";

        public void Activate(IPlayer player1, IPlayer player2)
        {
            player1.Mana -= Cost;
            player1.HP += 10; 
        }
    }
}
