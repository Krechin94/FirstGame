﻿using PizdilovoGame.Rassi;
using PizdilovoGame.Weapons;
using System;
using System.Collections.Generic;

namespace PizdilovoGame
{
    public class Player : IPlayer
    {
        private IWeapon _currentWeapon;

        private readonly Random _random = new Random();
        private readonly VvodChisla _vvodChisla = new VvodChisla();

        public int HP { get; set; }
        public int Stamina { get; set; }
        public string Name { get; set; }        
        public string Nation { get; set; }
        public int KudaYdar { get; set; }

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
                
                Console.WriteLine("Куда бить 1 - голова, 2 - туловище, 3 - ноги");
                _vvodChisla.Vvod();

                Console.WriteLine(this.Name + " " + this.HP);
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

                ProverkaNaCombo(kuda);
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

        int[] _combo = new int[2] { 1, 2 };
        Queue<int> _comboHitQueue = new Queue<int>();
        public void ProverkaNaCombo(int kudaYdaril)
        {
            if (_comboHitQueue.Count == _combo.Length)
            {
                _comboHitQueue.Dequeue();
            }
            _comboHitQueue.Enqueue(kudaYdaril);
            int[] _comboHit = _comboHitQueue.ToArray();
            for (int j = 0; j < _comboHit.Length; j++)
            {
                if (_combo[j] == _comboHit[j])
                {
                    if (j == _combo.Length - 1)
                    {
                        Console.WriteLine("Тебе повезло, ты открыл супер удар, поэтому бьешь еще раз");
                        this.HP =this.HP + kudaYdaril * 4;
                    }
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
