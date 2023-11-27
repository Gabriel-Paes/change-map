using ChangeMap.ChangeCoin;
using ChangeMap.ChangeInfo;

Console.WriteLine("Mapa de troco Programação Dinâmica");

double[] coins = [0.05, 0.10, 0.25, 0.50, 1, 2, 5, 10, 20, 50, 100, 200];

Console.Write("\nEntre com o valor para calcular o mapa de troco: ");

string input = Console.ReadLine() ?? string.Empty;

double value;
if (!double.TryParse(input, out value))
{
    Console.WriteLine("\nValor inválido!");
}

ChangeCoin[] changeCoins = Change(coins, value);

Console.WriteLine("\nMoedas para o troco:\n");
for (int i = changeCoins.Length - 1; i >= 0; i--)
{
    if (changeCoins[i].Amount > 0) {
        Console.WriteLine($"{changeCoins[i].Amount} moeda(s) de {changeCoins[i].Coin}");
    }
}

static ChangeCoin[] Change(double[] coins, double changeValue) {
    int changeInteger = (int)(changeValue * 100);
    int numCoins = coins.Length;
    ChangeInfo[] changeInfoArray = new ChangeInfo[changeInteger + 1];

    for (int i = 0; i <= changeInteger; i++) {
        changeInfoArray[i] = new ChangeInfo(int.MaxValue, 0);
    }

    for (int i = 1; i <= changeInteger; i++) {
        for (int j = 0; j < numCoins; j++) {
            int coinInteger = (int)(coins[j] * 100);

            if (coinInteger <= i && changeInfoArray[i - coinInteger].MinCoins + 1 < changeInfoArray[i].MinCoins) {
                changeInfoArray[i].MinCoins = changeInfoArray[i - coinInteger].MinCoins + 1;
                changeInfoArray[i].LastUsedCoin = j;
            }
        }
    }

    ChangeCoin[] change = new ChangeCoin[numCoins];
    for (int i = 0; i < numCoins; i++) {
        change[i] = new ChangeCoin(coins[i], 0);
    }

    int currentChange = changeInteger;

    while (currentChange > 0) {
        double currentCoin = coins[changeInfoArray[currentChange].LastUsedCoin];
        change[changeInfoArray[currentChange].LastUsedCoin].Amount++;
        currentChange -= (int)(currentCoin * 100);
    }

    return change;
}
