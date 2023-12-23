// 1
Console.WriteLine("--1--");
int[] decrease = new int[100];
for (int i = 0; i < 100; i++)
{
    decrease[i] = (300 - (i * 3));
    Console.Write($"{decrease[i]} ");
}
Console.WriteLine();
// 2
Console.WriteLine("--2--");
int[] odd = new int[100];
for (int i = 0; i < 100; i++)
{
    odd[i] = (i * 2) + 1;
    Console.Write($"{odd[i]} ");
}
Console.WriteLine();
// 3
Console.WriteLine("--3--");
int[,] matrix = new int[10, 10];
for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        if (i == 0 || j == 0)
        {
            matrix[i, j] = 1;
        }
        else
        {
            matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
        }
        if (matrix[i, j] < 10) Console.Write($"    {matrix[i, j]} ");
        else if (matrix[i, j] < 100) Console.Write($"   {matrix[i, j]} ");
        else if (matrix[i, j] < 1000) Console.Write($"  {matrix[i, j]} ");
        else if (matrix[i, j] < 10000) Console.Write($" {matrix[i, j]} ");
        else Console.Write($"{matrix[i, j]} ");
    }
    Console.WriteLine();
}
// 4
Console.WriteLine("--4--");
int[,] temperature = new int[12, 30];
double[] average = new double[12];
Random rnd = new Random();
Console.WriteLine("Average: ");
for (int i = 0; i < 12; i++)
{
    switch (i)
    {
        case 0: Console.Write("January: "); break;
        case 1: Console.Write("February: "); break;
        case 2: Console.Write("March: "); break;
        case 3: Console.Write("April: "); break;
        case 4: Console.Write("May: "); break;
        case 5: Console.Write("June: "); break;
        case 6: Console.Write("July: "); break;
        case 7: Console.Write("August: "); break;
        case 8: Console.Write("September: "); break;
        case 9: Console.Write("October: "); break;
        case 10: Console.Write("November: "); break;
        case 11: Console.Write("December: "); break;
    }
    int sum = 0;
    for (int j = 0; j < 30; j++)
    {
        if (i < 2 || i == 11) temperature[i, j] = rnd.Next(-45, -5);
        else if (i < 5 || i >= 8) temperature[i, j] = rnd.Next(-5, 20);
        else temperature[i, j] = rnd.Next(10, 45);
        // Console.Write($"{temperature[i, j]} ");
        // if ((j + 1) % 7 == 0) Console.WriteLine();
        // если надо посмотреть все температуры
        sum += temperature[i, j];
    }

    average[i] = (sum / 30.0);
    Console.WriteLine($"{average[i]} ");
}
Array.Sort(average);
Console.Write("Average sort: ");
foreach (var num in average)
{
    Console.Write($"{num} ");
}
Console.WriteLine();
// 5
Console.WriteLine("--5--");
Dictionary<string, int[]> temperature2 = new Dictionary<string, int[]>();
Random random = new Random();
for (int i = 0; i < 12; i++)
{
    int[] monthTemp = new int[30];
    for (int j = 0; j < 30; j++)
    {
        if (i < 2 || i == 11) monthTemp[j] = random.Next(-45, -5);
        else if (i < 5 || i >= 8) monthTemp[j] = random.Next(-5, 20);
        else monthTemp[j] = random.Next(10, 45);
    }
    switch (i)
    {
        case 0: temperature2.Add("January", monthTemp); break;
        case 1: temperature2.Add("February", monthTemp); break;
        case 2: temperature2.Add("March", monthTemp); break;
        case 3: temperature2.Add("April", monthTemp); break;
        case 4: temperature2.Add("May", monthTemp); break;
        case 5: temperature2.Add("June", monthTemp); break;
        case 6: temperature2.Add("July", monthTemp); break;
        case 7: temperature2.Add("August", monthTemp); break;
        case 8: temperature2.Add("September", monthTemp); break;
        case 9: temperature2.Add("October", monthTemp); break;
        case 10: temperature2.Add("November", monthTemp); break;
        case 11: temperature2.Add("December", monthTemp); break;
    }
}
Dictionary<string, double> averageTemperature = new Dictionary<string, double>();
Console.WriteLine("Average:");
foreach (var dictionary in temperature2)
{
    int sum = 0;
    for (int i = 0; i < 30; i++)
    {
        sum += dictionary.Value[i];
    }
    Console.WriteLine($"{dictionary.Key}, {sum/30.0}");
    averageTemperature.Add(dictionary.Key, (sum / 30.0));
}
Console.WriteLine("Sorted average:");
var sortedTemperature = averageTemperature.OrderBy(x => x.Value);
foreach (var dictionary in sortedTemperature)
{
    Console.WriteLine($"{dictionary.Key}, {dictionary.Value}");
}