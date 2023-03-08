using System;

namespace PizdilovoGame
{
    public class Champ

    {
        Random random = new Random();
        public string Name { get; set; }
        public int Stamina { get; set; }
        private int HP { get; set; } = 10;
        public Champ(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;

        }

        public override string ToString()
        {
            return $"{Name} Age: {Stamina}";
        }
        public void ydar(Champ champ)
        {
            Baffi buf = new Baffi();
            Console.WriteLine("Куда бить 1 - голова, 2 - туловище, 3 - ноги");
            int kuda = int.Parse(Console.ReadLine());
            Console.WriteLine(this.Name + " " + this.HP);
            switch (kuda)
            {
                case 1:
                    {
                        int a = random.Next(0, 4);
                        champ.HP = champ.HP - a;
                        Console.WriteLine($" ты наносишь {a} урона");
                        break;
                        
                    }
                case 2:
                    {
                        int b = random.Next(1, 3);
                        champ.HP = champ.HP - b;
                        Console.WriteLine($" ты наносишь {b} урона");
                        break;
                    }
                case 3:
                    {
                        champ.HP = champ.HP - 1;
                        Console.WriteLine($" ты наносишь 1 урон");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Какой же ты тупой, я же написал от 1 до 3, это 1 или 2 или 3!!!!!!!");
                        break;
                    }
            }
            int buff = random.Next(0, 4);
            if (buff == 0)
            {
                buf.Buffs(this, champ);
            }
            else
            {
                Console.WriteLine("Без баффов");
            }

           

        }
        public void PlusHp(int skokhpsnesti )
        {
            this.HP = this.HP + skokhpsnesti;

        }
        public int skokHP()
        {
            return this.HP;
        }
    }
}
