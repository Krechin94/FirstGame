using PizdilovoGame.Rassi;
using System;
using System.Collections.Generic;


namespace PizdilovoGame.GameLogic
{
    internal class ComboHitLogic
    {
        int[] _combo = new int[2] { 1, 2 };
        Queue<int> _comboHitQueue = new Queue<int>();

        public void ProverkaNaCombo(IPlayer player)
        {
            if (_comboHitQueue.Count == _combo.Length)
            {
                _comboHitQueue.Dequeue();
            }
            _comboHitQueue.Enqueue(player.KudaYdar);
            int[] _comboHit = _comboHitQueue.ToArray();
            for (int j = 0; j < _comboHit.Length; j++)
            {
                if (_combo[j] == _comboHit[j])
                {
                    if (j == _combo.Length - 1)
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
