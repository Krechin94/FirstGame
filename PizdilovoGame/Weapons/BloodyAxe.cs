using PizdilovoGame.Rassi;

namespace PizdilovoGame.Weapons
{
    internal class BloodyAxe : IWeapon
    {
        public string Name { get; set; } = "BloodyAxe";
        public string Description { get; set; } = "Double hand axe, which can scare your opponent";

        public int Uron { get; } = 10;

        public int Cost { get; } = 2;

        public string Affiliation { get; set; } = "Human";

        public void Equip(IPlayer player)
        {
            player.Uron += Uron;

            if (player.Nation == Affiliation)
            {
                player.HP += 5;
                player.ChanceToKrit += 5;
            }
        }
    }
}
