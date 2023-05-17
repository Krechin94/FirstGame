

namespace PizdilovoGame.Weapons
{
    public interface IWeapon
    {
        string Name { get; }

        int Uron { get; } 

        int Cost { get; }

        string Description { get; }

        string Affiliation { get; }
    }
}
