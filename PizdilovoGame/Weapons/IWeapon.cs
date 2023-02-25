using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizdilovoGame.Weapons
{
    public interface IWeapon
    {
        string Name { get; }

        int Uron { get; } 

        int Cost { get; }
    }
}
