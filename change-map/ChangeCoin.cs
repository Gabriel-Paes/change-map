namespace ChangeMap.ChangeCoin
{
    public class ChangeCoin(double coin, int amount)
    {
        public double Coin { get; set; } = coin;
        public int Amount { get; set; } = amount;
    }
}