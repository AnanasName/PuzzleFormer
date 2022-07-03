using System;
using UnityEngine;

namespace PixelPuzzle.Model
{
    [Serializable]
    public class PlayerData
    {
        public PlayerData(int coins, int hp, bool isArmed)
        {
            Coins = coins;
            Hp = hp;
            IsArmed = isArmed;
        }

        public int Coins;
        public int Hp;
        public bool IsArmed;
    }
}