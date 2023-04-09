using PizdilovoGame.Buffs;
using PizdilovoGame.Exceptions;
using PizdilovoGame.GameLogic;
using PizdilovoGame.Rassi;
using PizdilovoGame.Weapons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace PizdilovoGame
{
    public class Player : IPlayer
    {
        private IWeapon _currentWeapon;
        private int _hp;
        private int _stamina;
        private readonly Random _random = new Random();
        private readonly VvodChisla _vvodChisla = new VvodChisla();
        private const int MaxMana = 10;
        private const int MinMana = 0;
        private int sec;
        private int kuda;
        private CancellationTokenSource _readLineCancellation = new CancellationTokenSource();
        private Timer _readLineTimer;

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

        public Player()
        {
            _readLineTimer = new Timer(1000);
            _readLineTimer.Elapsed += Message;
        }

        public async void Udar(IPlayer enemy)
        {
            List<IBuffs> list = ChekingBuffsForYou(allBuffsOfPlayers, this, enemy);
            ViborBuffs(list, this, enemy);
            Console.WriteLine($"Сейчас бьет {Name}");
            kuda = 0;
            sec = 3;
            Show(sec);
            Console.WriteLine("Куда бить 1 - голова, 2 - туловище, 3 - ноги");

            // trigger hp and mana info printing
            HpAndManaChanged();
            Console.SetCursorPosition(0, 3);

            kuda =  ChooseAttackType();

            _readLineCancellation = new CancellationTokenSource();
            _readLineTimer.Stop(); 
            Console.Clear();

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
                        int c = 4;
                        enemy.HP = enemy.HP - c;
                        this.Mana++;
                        Console.WriteLine($" ты наносишь 4 урона");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine($" ты пропустил свой удар");
                        break;
                    }
            }
            ProverkaNaCombo(kuda);
        }

        public void Equip(IWeapon weapon)
        {
            _currentWeapon = weapon;
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
                this.HP = this.HP + kudaYdaril * 4;
            }
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
                _vvodChisla.Vvod(count);
                int chislo = _vvodChisla.number;
                buffs[chislo - 1].Activate(player1, player2);
                Console.Clear();
            }
        }
        public void Show(int vremya)
        {
            _readLineTimer.Start();
        }

        private void Message(object sender, ElapsedEventArgs e)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, 0);
            Console.Write(sec);
            sec--;
            Console.SetCursorPosition(0, 5);
            if (sec < 0)
            {
                _readLineCancellation.Cancel();
                _readLineTimer.Stop();
            }
        }

        private int ChooseAttackType()
        {
            try
            {
                return ReadLineAsync(_readLineCancellation.Token).Result;
            } 
            catch (AggregateException tce)
            {
                return 4;
            }
        }


        async Task<int> ReadLineAsync(CancellationToken cancellationToken = default)
        {
            var readTask = Task.Run(() =>
            {
                _vvodChisla.Vvod(3);
                return _vvodChisla.number;
            });

            await Task.WhenAny(readTask, Task.Delay(-1, cancellationToken));

            if (cancellationToken.IsCancellationRequested)
                throw new WrongUserInputException(3);

            return await readTask;
        }
    }
}