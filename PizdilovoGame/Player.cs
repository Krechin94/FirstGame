using PizdilovoGame.Buffs;
using PizdilovoGame.GameLogic;
using PizdilovoGame.Rassi;
using PizdilovoGame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Udar(IPlayer enemy)
        {
            List<IBuffs> list = ChekingBuffsForYou(allBuffsOfPlayers, this, enemy);
            Console.SetCursorPosition(0, 3);
            ViborBuffs(list, this, enemy);
            WritingInConsole.WhoPunchWhereToPunchText(Name);
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
                        WritingInConsole.DamageYouInflictText(a);
                        break;
                    }
                case 2:
                    {
                        int b = _random.Next(3, 6);
                        enemy.HP = enemy.HP - b;
                        this.Mana++;
                        WritingInConsole.DamageYouInflictText(b);
                        break;
                    }
                case 3:
                    {
                        enemy.HP = enemy.HP - 4;
                        this.Mana++;
                        WritingInConsole.DamageYouInflictText(4);
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
                WritingInConsole.SuperComboText(kudaYdaril);
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
                        WritingInConsole.BuffsListText(buff, i);
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
                WritingInConsole.WhoPunchWhatBuffUseText(Name, count);
                _vvodChisla.Vvod(count);
                int chislo = _vvodChisla.number;
                buffs[chislo - 1].Activate(player1, player2);
                Console.Clear();
            }
        }
    }
}