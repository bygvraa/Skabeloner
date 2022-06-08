using System.Diagnostics;

namespace InsertionSort;

public class SortTester
{
    public static void Run()
    {
        int testSize = 100000;
        int Min = 0;
        int Max = 10000;
        Random randNum = new();

        int[] bigArray = Enumerable
            .Repeat(0, testSize)
            .Select(i => randNum.Next(Min, Max))
            .ToArray();

        int[] bigArray2 = (int[])bigArray.Clone();

        Stopwatch stopWatch = new();

        // Insertion Sort Test
        stopWatch.Start();
        InsertionSort.Sort(bigArray2);
        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("InsertionSort: " + elapsedTime);
    }

}