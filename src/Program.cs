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

namespace tryYield
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Test2();
            Console.Read();
        }

        private static void Test1()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int[] a = new int[10];
            a = Generator1(2, 10);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(a[i]);
            }
            timer.Stop();
            Console.WriteLine($"Time taken: {timer.Elapsed}");
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
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var item in Generator2(2, 10))
            {
                Console.Write(item);
            }
            sw.Stop();
            Console.WriteLine($"Time taken: {sw.Elapsed}");
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
