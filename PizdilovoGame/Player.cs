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
                List<IBuffs> list = ChekingBuffsForYou(allBuffsOfPlayers, this, enemy);
                Console.SetCursorPosition(0, 3);
                ViborBuffs(list, this, enemy);
                Console.WriteLine($"Сейчас бьет {Name}");
                Console.WriteLine("Куда бить 1 - голова, 2 - туловище, 3 - ноги");
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

        private List<IBuffs> ChekingBuffsForYou(List<IBuffs> buffs, IPlayer player1, IPlayer player2)
        {
            int i = 0;
            List<IBuffs> list = new List<IBuffs>();
            foreach (var buff in buffs)
            {
                if (player1.Mana >= buff.Cost)
                {
                    if (player1.Nation == buff.Affiliations || buff.Affiliations =="All")
                    {
                        string text = $"Заклинание номер - {i+1} {buff.Name}\n";
                        Console.SetCursorPosition((Console.WindowWidth) - text.Length, 4 + i);
                        Console.WriteLine(text);
                        list.Add(buff);
                        i++;
                    }
                }
            }
            return list;
        }

        private void ViborBuffs(List<IBuffs> buffs, IPlayer player1, IPlayer player2)
        {
            if (buffs.Count > 0)
            {
                int count = buffs.Count;
                Console.WriteLine($"Vvedi Chislo ot 1 do {count}");
                int chislo = int.Parse(Console.ReadLine());
                buffs[chislo - 1].Activate(player1, player2);
                Console.Clear();
            }
        }
    }
}