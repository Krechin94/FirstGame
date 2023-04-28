using PizdilovoGame.Rassi;

namespace PizdilovoGame.Buffs
{
    internal class WetWilly : IBuffs
    {
        public string Name { get; } = "WetWilly";

        public int Cost { get; } = 6;
        public string Affiliations { get; } = "Human";
        public string Description { get; } = "Заклинание 'Мокрый Вилли' Доступно только Людям. Отнимает у врага 10 здоровья. Стоит 3 маны";

        public void Activate(IPlayer player1, IPlayer player2)
        {
            player1.Mana -= Cost / 2;
            player2.HP -= 10;
        }
    }
}
