// 1
Console.WriteLine("--1--");
Console.Write("Write number: ");
int n = int.Parse(Console.ReadLine() ?? string.Empty);
int multiply = 1;
for (int i = 3; i <= n; i+=3)
{
    multiply *= i;
}
Console.WriteLine(multiply);
// 2
Console.WriteLine("--2--");
using StreamReader text = new StreamReader("../../../numsTask2.txt");
text.BaseStream.Position = 0;
string numsString = await text.ReadLineAsync() ?? string.Empty;
text.Close();
List<int> nums = numsString.Split(';').ToList().Select(int.Parse).ToList();
int sum = 0;
foreach (var num in nums)
{
    if (num == 0) break;
    if (num < 0) continue;
    sum += num;
}
Console.WriteLine(sum);
// 3
Console.WriteLine("--3--");
using StreamReader text1 = new StreamReader("../../../numsTask3.txt");
text1.BaseStream.Position = 0;
string numsString1 = await text1.ReadLineAsync() ?? string.Empty;
text1.Close();
List<int> nums1 = numsString1.Split(',').ToList().Select(int.Parse).ToList();
int min = nums1[0];
int max = nums1[0];
foreach (var num in nums1)
{
    if (num == 0) break;
    if (num < min) min = num;
    if (num > max) max = num;
}
Console.WriteLine($"{max}/{min}={max/min}");
// 4
Console.WriteLine("--4--");
using StreamReader text2 = new StreamReader("../../../numsTask4.txt");
text2.BaseStream.Position = 0;
string numsString2 = await text2.ReadLineAsync() ?? string.Empty;
text2.Close();
List<int> nums2 = numsString2.Split(' ').ToList().Select(int.Parse).ToList();
int copyCount = 0;
List<int> copyCounters = new List<int>();
for (int i = 0; i < nums2.Count; i++)
{
    int last = 0;
    int next = 0;
    if (i < nums2.Count-1) next = nums2[i+1];
    if (i > 0) last = nums2[i-1];
    if (last == nums2[i]) copyCount++;
    else
    {
        copyCounters.Add(copyCount);
        copyCount = 0;
    }
    if (next == nums2[i] && last != nums2[i]) copyCount++;
}
copyCounters.Add(copyCount);
Console.WriteLine(copyCounters.Max());
// 5
Console.WriteLine("--5--");
Console.Write("Write a: ");
float a = float.Parse(Console.ReadLine() ?? string.Empty);
Console.Write("Write b: ");
float b = float.Parse(Console.ReadLine() ?? string.Empty);
if (a is <= 3 and >= -1 && b is <= 4 and >= -2) Console.WriteLine(true);
else Console.WriteLine(false);
// 6
Console.WriteLine("--6--");
Console.Write("Write a: ");
float a1 = float.Parse(Console.ReadLine() ?? string.Empty);
Console.Write("Write b: ");
float b1 = float.Parse(Console.ReadLine() ?? string.Empty);
if (a1 is >= 0 and <= 2 && b1 <= 2 - 2.5 * a1 && b1 >= -3) Console.WriteLine(true);
else if (a1 is < 0 and >= -2 && b1 <= 2 + 2.5 * a1 && b1 >= -3) Console.WriteLine(true);
else Console.WriteLine(false);