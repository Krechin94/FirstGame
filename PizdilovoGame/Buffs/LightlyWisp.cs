using PizdilovoGame.Rassi;

namespace PizdilovoGame.Buffs
{
    internal class LightlyWisp : IBuffs
    {
        public string Name { get; } = "LightlyWisp";
        public int Cost { get; } = 6;

        public string Affiliations { get; } = "Elf";
        public string Description { get; } = "Заклинание 'Легкий Пук' Доступно только эльфам. Восстанавливает 10 здоровья и 3 маны. Стоит 3 маны";

        public void Activate(IPlayer player1, IPlayer player2)
        {
            player1.Mana -= Cost;
            player2.HP -= 10;
            player2.Mana -= 3;
        }
    }
}
