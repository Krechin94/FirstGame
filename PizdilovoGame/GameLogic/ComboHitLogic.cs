using PizdilovoGame.Rassi;
using System;
using System.Collections.Generic;


namespace PizdilovoGame.GameLogic
{
    internal class ComboHitLogic
    {
        public int HitType { get; set; }
        int[] combo = new int[2] { 1, 2 };
        Queue<int> comboHitQueue = new Queue<int>();

        public void ProverkaNaCombo(IPlayer player)
        {
            if (comboHitQueue.Count == combo.Length)
            {
                comboHitQueue.Dequeue();
            }
            comboHitQueue.Enqueue(player.KudaYdar);
            int[] comboHit = comboHitQueue.ToArray();
            for (int j = 0; j < comboHit.Length; j++)
            {
                if (combo[j] == comboHit[j])
                {
                    if (j == combo.Length - 1)
                    {
                        Console.WriteLine("Тебе повезло, ты открыл супер удар, поэтому бьешь еще раз");
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
