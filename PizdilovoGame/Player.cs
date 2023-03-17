using PizdilovoGame.Buffs;
using PizdilovoGame.GameLogic;
using PizdilovoGame.Rassi;
using PizdilovoGame.Weapons;
using System;
using System.Collections.Generic;

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

        public int Mana 
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

        List<IBuffs> allBuffsOfPlayers = new List<IBuffs>
        {
            new HpRestoring(),
            new LightlyWisp(),
            new ManaRestoring(),
            new SpitIntoTheFace(),
            new WetWilly(),
        };

        public void Udar(IPlayer enemy)
        {
            if (_currentWeapon == null)
            {
                enemy.HP--;
                this.Mana--;
            }
            else
            {
                Console.WriteLine($"Сейчас бьет {Name}");
                Console.WriteLine("Куда бить 1 - голова, 2 - туловище, 3 - ноги");
                ChekingBuffsForYou(allBuffsOfPlayers, this);
                Console.SetCursorPosition(0, 3);
                _vvodChisla.Vvod();
                Console.Clear();
                var kuda = _vvodChisla.Number;
                switch (kuda)
                {
                    case 1:
                        {
                            int a = _random.Next(1, 10);
                            enemy.HP = enemy.HP - a;
                            ManaNotBigger10(this);
                            Console.WriteLine($" ты наносишь {a} урона");
                            break;
                        }
                    case 2:
                        {
                            int b = _random.Next(3, 6);
                            enemy.HP = enemy.HP - b;
                            ManaNotBigger10(this);
                            Console.WriteLine($" ты наносишь {b} урона");
                            break;
                        }
                    case 3:
                        {
                            enemy.HP = enemy.HP - 4;
                            ManaNotBigger10(this);
                            Console.WriteLine($" ты наносишь 4 урона");
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
            return Name;
        }

        private void ManaNotBigger10 (IPlayer player)
        {
            if (player.Mana < 10)
            {
                player.Mana++;
            }
        }

        private void ChekingBuffsForYou(List<IBuffs> buffs, IPlayer player1)
        {
            int i = 0;
            foreach (var buff in buffs)
            {
                if (player1.Mana >= buff.Cost)
                {
                    if (player1.Nation == buff.Affiliations || buff.Affiliations =="All")
                    {
                        string text = "Вы можете использовать" + buff.Name + "\n";
                        Console.SetCursorPosition((Console.WindowWidth) - text.Length, 4 + i);
                        Console.WriteLine(text);
                        i++;
                    }
                }
            }
        }
    }
}