using ChangeMap.ChangeCoin;

Console.WriteLine("Hello, World!");

double[] coins = [0.05, 0.10, 0.25, 0.50, 1, 2, 5, 10, 20, 50, 100, 200];

Console.Write("{");
for (int i = 0; i < coins.Length; i++)
{
    Console.Write($" {coins[i]}");
}
Console.Write(" }");

Console.Write("\n\nEntre com o valor para calcular o mapa de troco: ");

string input = Console.ReadLine() ?? string.Empty;

double value;
if (!double.TryParse(input, out value))
{
    Console.WriteLine("Valor inválido!");
}

var changeCoins = Change(coins, value);

for (int i = changeCoins.Length - 1; i >= 0; i--)
{
    if (changeCoins[i] != null)
    {
        Console.WriteLine($"{changeCoins[i].Amount} moedas de {changeCoins[i].Coin}");
    }
}

static ChangeCoin[] Change(double[] coins, double value)
{
    var change = new ChangeCoin[coins.Length];

    for (int i = coins.Length - 1; i >= 0; i--)
    {
        var amount = (int)(value / coins[i]);
        if (amount > 0)
        {
            change[i] = new ChangeCoin(coins[i], amount);
            value -= coins[i] * amount;
            value = Math.Round(value, 2);
        }
    }

    return change;
}