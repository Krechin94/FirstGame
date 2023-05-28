using PizdilovoGame.Buffs;
using PizdilovoGame.GameLogic;
using PizdilovoGame.Rassi;
using PizdilovoGame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PizdilovoGame
{
    public class Player : IPlayer
    {
        private IWeapon _currentWeapon1;
        private IWeapon _currentWeapon2;
        private int _hp;
        private int _stamina;
        private readonly Random _random = new Random();
        private readonly VvodChisla _vvodChisla = new VvodChisla();
        private const int MaxMana = 10;
        private const int MinMana = 0;

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
                if (value < MinMana)
                    _stamina = 0;
                if (value > MaxMana)
                    _stamina = 10;

                if (_stamina == value)
                    return;

                HpAndManaChanged?.Invoke();
            }
        }
        public int Uron { get; set; } = 0;
        public int ChanceToBlock { get; set; } = 0;
        public int ChanceToKrit { get; set; } = 0;
        public int ChanceToDodge { get; set; } = 0;
        public string Name { get; set; }
        public string Nation { get; set; }

        List<IBuffs> allBuffsOfPlayers = new List<IBuffs>
        {
            new HpRestoring(),
            new ManaRestoring(),
            new LightlyWisp(),
            new SpitIntoTheFace(),
            new WetWilly(),
        };

        /*List<IWeapon> weapons = new List<IWeapon>
        {
            new BloodyAxe(),
            new LeftHandElfSword(),
            new RightHandElfSword(),
            new TurtuleShield(),
            new TurtuleSword(),
        };*/

        public void Udar(IPlayer enemy)
        {
                List<IBuffs> list = ChekingBuffsForYou(allBuffsOfPlayers, this, enemy);
                Console.SetCursorPosition(0, 3);
                ViborBuffs(list, this, enemy);
                Console.WriteLine($"Сейчас бьет {Name}");
                Console.WriteLine("Куда бить 1 - голова, 2 - туловище, 3 - ноги");
                _vvodChisla.Vvod(3);
                Console.Clear();
                var kuda = _vvodChisla.number;
                switch (kuda)
                {
                    case 1:
                        {
                            int a = _random.Next(1, 10);
                            enemy.HP = enemy.HP - a;
                            this.Mana++;
                            Console.WriteLine($" ты наносишь {a} урона");
                            break;
                        }
                    case 2:
                        {
                            int b = _random.Next(3, 6);
                            enemy.HP = enemy.HP - b;
                            this.Mana++;
                            Console.WriteLine($" ты наносишь {b} урона");
                            break;
                        }
                    case 3:
                        {
                            enemy.HP = enemy.HP - 4;
                            this.Mana++;
                            Console.WriteLine($" ты наносишь 4 урона");
                            break;
                        }
                }

                ProverkaNaCombo(kuda);
        }

        public override string ToString()
        {
            return Name;
        }

        int[] _combo = new int[3] { 1, 2, 3 };
        Queue<int> _comboHitQueue = new Queue<int>();
        public void ProverkaNaCombo(int kudaYdaril)
        {
            if (_comboHitQueue.Count == _combo.Length)
            {
                _comboHitQueue.Dequeue();
            }
            _comboHitQueue.Enqueue(kudaYdaril);

            if (_combo.SequenceEqual(_comboHitQueue))
            {
                Console.WriteLine("Тебе повезло, ты открыл супер удар, поэтому бьешь еще раз");
                Thread.Sleep(2000);
                this.HP = this.HP + kudaYdaril * 4;
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
                _vvodChisla.Vvod(count);
                int chislo = _vvodChisla.number;
                buffs[chislo - 1].Activate(player1, player2);
                Console.Clear();
            }
        }
    }
}