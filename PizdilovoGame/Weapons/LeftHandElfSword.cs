using PizdilovoGame.Rassi;

namespace PizdilovoGame.Weapons
{
    internal class LeftHandElfSword : IWeapon
    {
        public string Name { get; set; } = "LeftHandSword";
        public string Description { get; set; } = "Light sword that can fully open only in elf's hand";

        public int Uron { get; } = 5;

        public int Cost { get; } = 1;

        public string Affiliation { get; set; } = "elf";

        public void Equip(IPlayer player)
        {
            player.Uron += Uron;
            if (player.Nation == Affiliation)
            {
                player.HP += 3;
                player.ChancetoBlock += 2;
            }
        }
    }
}
