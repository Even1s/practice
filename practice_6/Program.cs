// 1
using StreamReader text = new StreamReader("../../../numsTask1.txt");
text.BaseStream.Position = 0;
string wordsString = await text.ReadLineAsync() ?? string.Empty;
text.Close();
List<string> words = wordsString.Split(' ').ToList();
foreach (var word in words)
{
    if (word.Length % 2 != 0) Console.WriteLine(word);
}
// 2
using StreamReader text1 = new StreamReader("../../../numsTask2.txt");
text1.BaseStream.Position = 0;
string words1 = "";
while (!text1.EndOfStream)
{
    string wordString = await text1.ReadLineAsync() ?? string.Empty;
    words1 += wordString + " ";
}

words1 = words1.Remove(words1.Length - 1);
text1.Close();
Console.WriteLine($"'{words1}'");
// 3
int a = int.Parse(Console.ReadLine() ?? string.Empty);
Console.WriteLine(a % 10 == 0);
// 4
int b = int.Parse(Console.ReadLine() ?? string.Empty);
if (b <= 0) return;
int sum = 0;
do
{
    int num = int.Parse(Console.ReadLine() ?? string.Empty);
    if (num > 0 && num % b == 0) sum += num;
    else if (num <= 0) break;
} while (true);
Console.WriteLine(sum);
// 5
int n = int.Parse(Console.ReadLine() ?? string.Empty);
int m = int.Parse(Console.ReadLine() ?? string.Empty);
int[,] matrix = new int[n,m+1];
Random rnd = new Random();
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        matrix[i,j] = rnd.Next(0, 2);
        Console.Write($"{matrix[i,j]} ");
    }
    Console.WriteLine();
}
for (int i = 0; i < n; i++)
{
    int sum1 = 0;
    for (int j = 0; j < m; j++)
    {
        sum1 += matrix[i, j];
        Console.Write($"{matrix[i,j]} ");
    }

    matrix[i,m] = sum1 % 2;
    Console.Write($"{matrix[i,m]} ");
    Console.WriteLine();
}
// 6
string numsString = Console.ReadLine() ?? string.Empty;
if (numsString == "") return;
float[] nums = numsString.Split(' ').ToArray().Select(float.Parse).ToArray();
List<float> positive = new List<float>();
List<float> negative = new List<float>();
foreach (var num in nums)
{
    if (num > 0) positive.Add(num);
    else if (num < 0) negative.Add(num);
}

foreach (var num in positive) Console.Write($"{num} ");
Console.WriteLine();
foreach (var num in negative) Console.Write($"{num} ");
Console.WriteLine();