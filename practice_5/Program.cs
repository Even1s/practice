// 1
Console.WriteLine("--1--");
using StreamReader text = new StreamReader("../../../numsTask1.txt");
text.BaseStream.Position = 0;
string numsString = await text.ReadLineAsync() ?? string.Empty;
text.Close();
List<int> nums = numsString.Split(' ').ToList().Select(int.Parse).ToList();
int min = nums[0];
foreach (var num in nums) if (min > num) min = num;
int minIndex = nums.IndexOf(min);
int multiply = 1;
for (int i = minIndex+1; i < nums.Count; i++) multiply *= nums[i];
Console.WriteLine(multiply);
// 2
Console.WriteLine("--2--");
using StreamReader text1 = new StreamReader("../../../numsTask2.txt");
text1.BaseStream.Position = 0;
string numsString1 = await text1.ReadLineAsync() ?? string.Empty;
text1.Close();
List<float> nums1 = numsString1.Split(';').ToList().Select(float.Parse).ToList();
for (int i = 0; i < nums1.Count; i++)
{
    float min1 = nums1[i];
    for (int j = i + 1; j < nums1.Count; j++) if (min1 > nums1[j]) min1 = nums1[j];
    int minIndex1 = nums1.IndexOf(min1);
    (nums1[i], nums1[minIndex1]) = (nums1[minIndex1], nums1[i]);
}
await using StreamWriter write = new StreamWriter("../../../numsTask2.txt", false);
for (int i = 0; i < nums1.Count; i++)
{
    write.Write(nums1[i]);
    if (i + 1 < nums1.Count) write.Write(';');
}
// 3
Console.WriteLine("--3--");
using StreamReader text2 = new StreamReader("../../../numsTask3.txt");
text2.BaseStream.Position = 0;
string numsString2 = await text2.ReadLineAsync() ?? string.Empty;
text2.Close();
List<int> nums2 = numsString2.Split(' ').ToList().Select(int.Parse).ToList();
int minIndex2 = nums2.IndexOf(nums2.Min());
int sum = 0;
for (int i = 0; i < minIndex2; i++) sum += nums2[i];
Console.WriteLine((sum*1.0)/(minIndex2*1.0));
// 4
Console.WriteLine("--4--");
using StreamReader text3 = new StreamReader("../../../numsTask4.txt");
text3.BaseStream.Position = 0;
string numsString3 = await text3.ReadLineAsync() ?? string.Empty;
text3.Close();
List<int> nums3 = numsString3.Split(' ').ToList().Select(int.Parse).ToList();
List<int> maxList = nums3.FindAll(num => num == nums3.Max() - 1);
int sum1 = 0;
foreach (var num in maxList) sum1 += num;
Console.WriteLine(sum1);
// 5
Console.WriteLine("--5--");
using StreamReader text4 = new StreamReader("../../../numsTask5.txt");
text4.BaseStream.Position = 0;
string numsString4 = await text4.ReadLineAsync() ?? string.Empty;
text4.Close();
List<int> nums4 = numsString4.Split(' ').ToList().Select(int.Parse).ToList();
int minIndex3 = nums4.IndexOf(nums4.Min());
int maxIndex = nums4.IndexOf(nums4.Max());
int count = Math.Max(maxIndex, minIndex3) - Math.Min(maxIndex, minIndex3) - 1;
int sum2 = 0;
for (int i = Math.Min(maxIndex, minIndex3)+1; i < Math.Max(maxIndex, minIndex3); i++) sum2 += nums4[i];
Console.WriteLine((sum2 * 1.0)/(count*1.0));