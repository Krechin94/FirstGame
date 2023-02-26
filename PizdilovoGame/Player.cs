using PizdilovoGame.Rassi;
using PizdilovoGame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizdilovoGame
{
    public class Player : IPlayer
    {
        Random random = new Random();
        public int HP { get; set; }

        public int Stamina { get; set; }
        public string Name { get; set; }
        
        public string Nation { get; set; }

        VvodChisla vvodChisla = new VvodChisla();

        private IWeapon _currentWeapon;

        public void Udar(IPlayer enemy)
        {
            if (_currentWeapon == null)
            {
                enemy.HP--;
                this.Stamina--;
            }
            else
            {
                enemy.HP = enemy.HP - _currentWeapon.Uron;
                this.Stamina = this.Stamina - _currentWeapon.Cost;
                Console.WriteLine($"{Name} нанес {_currentWeapon.Uron} урона. У {enemy.Name} осталось {enemy.HP} хп");
                
                
                    Baffi buf = new Baffi();
                    Console.WriteLine("Куда бить 1 - голова, 2 - туловище, 3 - ноги");
                int kuda= -1;
                vvodChisla.Vvod();
                kuda = vvodChisla.vvod;
                    Console.WriteLine(this.Name + " " + this.HP);
                    switch (kuda)
                    {
                        case 1:
                            {
                                int a = random.Next(0, 4);
                                enemy.HP = enemy.HP - a;
                                Console.WriteLine($" ты наносишь {a} урона");
                                break;

                            }
                        case 2:
                            {
                                int b = random.Next(1, 3);
                                enemy.HP = enemy.HP - b;
                                Console.WriteLine($" ты наносишь {b} урона");
                                break;
                            }
                        case 3:
                            {
                            
                                enemy.HP = enemy.HP - 1;
                                Console.WriteLine($" ты наносишь 1 урон");
                                int d = random.Next(0, 2);
                                if (d == 0)
                                {
                                Console.WriteLine("TEBE POVEZLO");
                                this.Udar(enemy);
                                    
                                }
                                break;
                            }
                      
                    }
                    /*int buff = random.Next(0, 4);
                    if (buff == 0)
                    {
                        buf.Buffs(this, enemy);
                   
                    }
                    else
                    {
                        Console.WriteLine("Без баффов");
                    }*/
                   


               

            }
        }

        public void Equip(IWeapon weapon)
        {
            _currentWeapon = weapon;
        }
        public override string ToString()
        {
            return $" {Name} Nation: {Nation}  Stamina: {Stamina} HP: {HP} Weapon: {_currentWeapon}";
        }
    }
}
