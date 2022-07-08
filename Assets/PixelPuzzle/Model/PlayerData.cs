using System;

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
            SwordsCount = 0;
        }
        
        public PlayerData(int coins, int hp, bool isArmed, int swordsCount)
        {
            Coins = coins;
            Hp = hp;
            IsArmed = isArmed;
            SwordsCount = swordsCount;
        }

        public int Coins;
        public int Hp;
        public bool IsArmed;
        public int SwordsCount;
    }
}