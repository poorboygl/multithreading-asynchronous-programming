int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

int SumSegment(int start, int end)
{
    int segmentSum = 0;
    for (int i = start; i < end; i++)
    {
        Thread.Sleep(100);
        segmentSum += array[i];
    }

    return segmentSum;
}



var startTime = DateTime.Now;

int numofThreads = 4;
int segmentLength = array.Length / numofThreads;

Thread[] threads = new Thread[numofThreads];
threads[0] = new Thread(() => {  SumSegment(0, segmentLength); });
threads[1] = new Thread(() => {  SumSegment(segmentLength, 2 * segmentLength); });
threads[2] = new Thread(() => {  SumSegment(2 * segmentLength, 3 * segmentLength); });
threads[3] = new Thread(() => {  SumSegment(3 * segmentLength, array.Length); });

foreach (var thread in threads) { thread.Start(); }
foreach (var thread in threads) { thread.Join(); }


var endTime = DateTime.Now;
var timespan = endTime - startTime;
Console.WriteLine($"The time it takes: {timespan.TotalMilliseconds}");

Console.ReadLine();