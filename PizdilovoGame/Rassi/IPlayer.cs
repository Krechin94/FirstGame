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

        void Udar(IPlayer enemy);

        void Equip(IWeapon weapon);
        
    }
}
