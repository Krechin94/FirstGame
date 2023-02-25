using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizdilovoGame.Weapons;

namespace PizdilovoGame.Rassi
{
    public interface IPlayer
    {
        int HP { get; set; }
        string Name { get; set; }   

        int Stamina { get; set; }

        void Udar(IPlayer enemy);

        void Equip(IWeapon weapon);
        
    }
}
