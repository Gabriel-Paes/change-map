namespace ChangeMap.ChangeInfo
{
    public class ChangeInfo(int minCoins, int lastUsedCoin)
    {
        public int MinCoins { get; set; } = minCoins;
        public int LastUsedCoin { get; set; } = lastUsedCoin;
    }
}