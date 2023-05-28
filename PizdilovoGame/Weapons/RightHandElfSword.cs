using PizdilovoGame.Rassi;
namespace PizdilovoGame.Weapons
{
    internal class RightHandElfSword : IWeapon
    {
        public string Name { get; set; } = "RightHandSword";
        public string Description { get; set; } = "Light sword that can fully open only in elf's hand";

        public int Uron { get; } = 5;

        public int Cost { get; } = 1;

        public string Affiliation { get; set; } = "elf";

        public void Equip(IPlayer player)
        {
            player.Uron += Uron;

            if (player.Nation == Affiliation)
            {
                player.HP += 2;
                player.ChanceToDodge += 3;
            }
        }
    }
}
