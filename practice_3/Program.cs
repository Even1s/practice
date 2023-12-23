// 1
Console.WriteLine("--1--");
using StreamReader text = new StreamReader("../../../input.txt");
await using StreamWriter write = new StreamWriter("../../../output.txt", false);
text.BaseStream.Position = 0;
var victoryNumbersString = await text.ReadLineAsync() ?? string.Empty;
List<int> victoryNumbers = victoryNumbersString.Split(' ').ToList().Select(int.Parse).ToList();
if (victoryNumbers.Count != 10) return;
int countOfTickets = int.Parse(await text.ReadLineAsync() ?? string.Empty);
for (int i = 0; i < countOfTickets; i++)
{
    var ticketString = await text.ReadLineAsync() ?? string.Empty;
    List<int> ticket = ticketString.Split(' ').ToList().Select(int.Parse).ToList();
    int bingo = 0;
    foreach (var number in ticket)
    {
        foreach (var victoryNumber in victoryNumbers)
        {
            if (number == victoryNumber) bingo++;
        }
    }
    write.WriteLine(bingo >= 3 ? "bingo" : "nope");
}
text.Close(); write.Close();
// 2
Console.WriteLine("--2--");
List<int> numbers;
using (StreamReader text1 = new StreamReader("../../../nums.txt"))
{
    text1.BaseStream.Position = 0;
    string numbersString = await text1.ReadLineAsync() ?? string.Empty;
    numbers = numbersString.Split(' ').ToList().Select(int.Parse).ToList();
}
await using StreamWriter write1 = new StreamWriter("../../../nums.txt", false);
for (int i = 0; i < numbers.Count; i++)
{
    if (numbers[i] % 2 == 1)
    {
        if (i != 0) write1.Write(' ');
        write1.Write(numbers[i]);
    }
}
write1.Close();
// 3
Console.WriteLine("--3--");
List<int> height;
using (StreamReader text2 = new StreamReader("../../../height.txt"))
{
    text2.BaseStream.Position = 0;
    var heightString = await text2.ReadLineAsync() ?? string.Empty;
    height = heightString.Split(' ').ToList().Select(int.Parse).ToList();
}
int max = 0;
for (int i = 0; i < height.Count; i++)
{
    for (int j = 0; j < height.Count; j++)
    {
        if (i == j) continue;
        int minHeight = Math.Min(height[i], height[j]);
        int length = Math.Abs(i - j);
        if (max < minHeight * length) max = minHeight * length;
    }
}
await using StreamWriter write2 = new StreamWriter("../../../height.txt", true);

write2.WriteLine(max);
