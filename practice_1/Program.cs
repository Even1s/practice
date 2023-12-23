// 1
Console.WriteLine("--1--");
int[] randomArray = new int[10];
Random rnd = new Random();
for (int i = 0; i < 10; i++)
{
    randomArray[i] = rnd.Next();
    Console.WriteLine($"{i}: {randomArray[i]}");
}
Console.WriteLine($"min: {randomArray.Min()}");
// 2
Console.WriteLine("--2--");
List<int> numbers = new List<int>();
float sum = 0;
int multiply = 1;
Console.WriteLine("write numbers, 0 for exit");
while (true)
{
    var num = int.Parse(Console.ReadLine() ?? string.Empty);
    if (num == 0) break;
    numbers.Add(num);
}
foreach (var number in numbers)
{
    sum += number;
    multiply *= number;
}
Console.WriteLine($"sum: {sum}; multiply: {multiply}; average: {sum/numbers.Count}");
// 3
Console.WriteLine("--3--");
List<string> myStrings = new List<string>();
string max = "";
string min = "";
Console.WriteLine("write strings, null for exit");
while (true)
{
    var myString = Console.ReadLine();
    if (string.IsNullOrEmpty(myString)) break;
    myStrings.Add(myString);
}
foreach (var str in myStrings)
{
    if (str.Length > max.Length) max = str;
    if (str.Length < min.Length || min == "") min = str;
}
Console.WriteLine($"max: {max}; min: {min};");
// 4
Console.WriteLine("--4--");
Console.Write("write size of random array: ");
int size = int.Parse(Console.ReadLine() ?? string.Empty);
int[] limitedRandomArray = new int[size];
Console.WriteLine("write start and end");
int start = int.Parse(Console.ReadLine() ?? string.Empty);
int end = int.Parse(Console.ReadLine() ?? string.Empty);
Random random = new Random();
for (int i = 0; i < size; i++)
{
    limitedRandomArray[i] = random.Next(start, end);
    Console.Write($"{limitedRandomArray[i]} ");
}
Console.WriteLine();
// 5
Console.WriteLine("--5--");
Console.Write("write some words: ");
string words = Console.ReadLine() ?? string.Empty;
int count = 0;
for (int i = 0; i < words.Length; i++)
{
    if ((words[i] == ' ' && words[i + 1] != ' ') || i == 0 )
    {
        count++;
    }
}
words = words.Insert(0, "Start ");
words = words.Insert(words.Length, " End");
Console.WriteLine($"{words}, {count}");
