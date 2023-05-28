using PizdilovoGame.Weapons;
using System;

namespace PizdilovoGame.Rassi
{
    public interface IPlayer
    {
        event Action HpAndManaChanged;
        int HP { get; set; }
        string Name { get; set; }   
        int Mana { get; set; }
        string Nation { get; set; }
        int Uron { get; set; }
        int ChanceToBlock { get; set; }
        int ChanceToKrit { get; set; }
        int ChanceToDodge { get; set; }

        void Udar(IPlayer enemy);
        
    }
}
