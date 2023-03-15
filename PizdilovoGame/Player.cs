using PizdilovoGame.GameLogic;
using PizdilovoGame.Rassi;
using PizdilovoGame.Weapons;
using System;

namespace PizdilovoGame
{
    public class Player : IPlayer
    {
        private IWeapon _currentWeapon;
        private int _hp;
        private int _stamina;
        private readonly Random _random = new Random();
        private readonly VvodChisla _vvodChisla = new VvodChisla();

        public event Action HpAndManaChanged;

        public int HP
        {
            get => _hp;
            set
            {
                _hp = value;

                HpAndManaChanged?.Invoke();
            }
        }
        public int Stamina 
        { 
            get => _stamina;
            set
            {
                _stamina = value;

                HpAndManaChanged?.Invoke();
            }
        }
        public string Name { get; set; }
        public string Nation { get; set; }

        public void Udar(IPlayer enemy)
        {
            if (_currentWeapon == null)
            {
                enemy.HP--;
                this.Stamina--;
            }
            else
            {
                Console.WriteLine($"Сейчас бьет {Name}");
                Console.WriteLine("Куда бить 1 - голова, 2 - туловище, 3 - ноги");
                _vvodChisla.Vvod();
                var kuda = _vvodChisla.Number;
                switch (kuda)
                {
                    case 1:
                        {
                            int a = _random.Next(0, 4);
                            enemy.HP = enemy.HP - a;
                            Console.WriteLine($" ты наносишь {a} урона");
                            break;
                        }
                    case 2:
                        {
                            int b = _random.Next(1, 3);
                            enemy.HP = enemy.HP - b;
                            Console.WriteLine($" ты наносишь {b} урона");
                            break;
                        }
                    case 3:
                        {
                            enemy.HP = enemy.HP - 1;
                            Console.WriteLine($" ты наносишь 1 урон");
                            int d = _random.Next(0, 2);
                            if (d == 0)
                            {
                                Console.WriteLine("TEBE POVEZLO");
                                this.Udar(enemy);
                            }
                            break;
                        }
                }
            }
        }

        public void Equip(IWeapon weapon)
        {
            _currentWeapon = weapon;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}