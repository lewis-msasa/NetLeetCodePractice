// See https://aka.ms/new-console-template for more information

//number of rescue boats
using InterviewPrepsLeetCode.HashMap;
using InterviewPrepsLeetCode.PointersAndSlidingWindow;

int[] weights = [3, 2, 2, 1]; int limit = 3; //limit is max weight, the boat takes max 2 people
var numberBoats = PointerSlidingWindowProblems.NumberRescueBoats(weights,limit);
Console.WriteLine($"2 people per trip. Expected 3 boats and got {numberBoats}");
weights = [1, 2, 2, 3, 4];  limit = 6; //can take 3
numberBoats = PointerSlidingWindowProblems.NumberRescueBoatsCanTakeThree(weights,limit);
Console.WriteLine($"3 people per trip. Expected 3 boats and got {numberBoats}");

//max area
int[] heights = [1, 8, 6, 2, 5, 4, 8, 3, 7];
var maxArea = PointerSlidingWindowProblems.MaxArea(heights);
Console.WriteLine($"Max area, expected 49 and found {maxArea}");
//move zeros
int[] arr = [0, 1, 0, 3, 12];
PointerSlidingWindowProblems.MoveZeroes(arr);
Console.WriteLine($"expecting [1, 3, 12, 0, 0]");
for (int i = 0; i < arr.Length; i++)
{
    Console.Write($"{arr[i]} ");
}
Console.WriteLine();
int[] nums = [1, 0, -1, 0, -2, 2]; int target = 0;
var fourSumResult = PointerSlidingWindowProblems.FourSum(nums, target);
Console.WriteLine($"4 sum expecting [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]] and got:");
Console.Write("[");
foreach (var res in fourSumResult)
{
    int counter = 0;
    Console.Write("[");
    foreach(var item in res)
    {
        counter++;
        var isLast = (counter == res.Count);
        Console.Write($"{item}");
        if (!isLast) Console.Write(",");
    }
    Console.Write("]");
}
Console.Write("]");

//hashing
var groups = HashMapProblems.GroupAnagramsAlt(["eat", "tea", "tan", "ate", "nat", "bat"]);
foreach(var group in groups)
{
    Console.WriteLine();
    foreach(var item in group)
    {
        Console.Write($"{item} ");
    }
    
}
int[] A = [1, 2], B = [-2, -1], C = [-1, 2], D = [0, 2];
var result = HashMapProblems.FourSumCount(A, B, C, D);
Console.WriteLine($"Expected 2 and got {result}");
Console.ReadLine();
