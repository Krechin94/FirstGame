using PizdilovoGame.Rassi;

namespace PizdilovoGame.Buffs
{
    internal interface IBuffs
    {
        string Name { get; }
        int Cost { get; }
        string Affiliations { get; }
        string Description { get; } 
        void Activate(IPlayer player1, IPlayer player2);
    }
}
