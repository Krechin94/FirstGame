using PizdilovoGame.Rassi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizdilovoGame
{
    public class Baffi
    {
        Random random = new Random();
        public string Name { get; set; }

        public void Buffs(Champ napadayshii, Champ zashishayshii)
        {
            int wtfbuff = random.Next(0, 4);
            
            switch (wtfbuff)
            {
                case 0:
                    {
                        Console.WriteLine("Пердёж отнимает у противника 1 хп и повышает твою жизнь на 1 хп");
                        napadayshii.PlusHp(1);
                        zashishayshii.PlusHp(-1);
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Утонченный пук дает тебе 2 хп");
                        napadayshii.PlusHp(2);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Плевок в лицо отнимает у противника 2 хп");
                        zashishayshii.PlusHp(-2);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Мокрый Вилли, 10% шанс нанести 5 урона");
                        int c = random.Next(0, 10);
                        if (c == 0) 
                        {
                            zashishayshii.PlusHp(-5);
                            Console.WriteLine("Офигеть, у тебя получилось и ты наносишь дополнительно 5 урона");
                        }
                        else
                        {
                            Console.WriteLine("Ну не вышло ничего, главное не расстраивайся, ведь все равно ты педик)))");
                        }                        
                        break;
                    }

            }
        }

        internal void Buffs(Player player, IPlayer enemy)
        {
            throw new NotImplementedException();
        }
    }
}
