// https://www.c-sharpcorner.com/UploadFile/5ef30d/understanding-yield-return-in-C-Sharp/
// Some examples are of a function with two arguments (int start, int number) 
// made ​​in even numbers starting from the starting number

// Results:
// 2468101214161820Time taken: 00:00:00.0078525
// 2468101214161820Time taken: 00:00:00.0009548

// Conclusion:
// using yield return is 8 times faster than traditional.

using System;
using System.Collections;
using System.Diagnostics;

namespace TryYield
{
  class Program
  {
    private static Stopwatch _traditionalStopwatch = new Stopwatch();
    private static Stopwatch _yieldStopwatch = new Stopwatch();

    static void Main(string[] args)
    {
      Test1();
      Test2();

      Console.WriteLine();
      Console.WriteLine($"Traditional elapsed time: {_traditionalStopwatch.Elapsed}");
      Console.WriteLine($"Yield-return elapsed time: {_yieldStopwatch.Elapsed}");
      Console.WriteLine($"Yield-return is {Math.Round(_traditionalStopwatch.Elapsed / _yieldStopwatch.Elapsed)}x faster.");
    }

    private static void Test1()
    {
      _traditionalStopwatch.Start();
      int[] a = new int[100];
      a = Generator1(2, 100);
      for (int i = 0; i < 100; i++)
      {
        Console.Write(a[i]);
      }
      _traditionalStopwatch.Stop();
    }

    private static int[] Generator1(int start, int number)
    {
      int[] n = new int[number];
      for (int i = 0; i < number; i++)
      {
        n[i] = start + 2 * i;
      }
      return n;
    }

    private static void Test2()
    {
      _yieldStopwatch.Start();
      foreach (var item in Generator2(2, 100))
      {
        Console.Write(item);
      }
      _yieldStopwatch.Stop();
    }

    private static IEnumerable Generator2(int start, int number)
    {
      for (int i = 0; i < number; i++)
      {
        yield return start + 2 * i;
      }
    }
  }
}
