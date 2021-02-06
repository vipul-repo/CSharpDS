using System;
using System.Collections.Generic;

namespace CSharpDS
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        #region ASCII POC
        private static void printAscii(char c)
        {
            foreach (byte b in System.Text.Encoding.UTF8.GetBytes(c.ToString()))
                Console.Write(b.ToString());
        }

        private static void printAscii(string str)
        {
            foreach (byte b in System.Text.Encoding.UTF8.GetBytes(str.ToCharArray()))
                Console.Write(b.ToString());
        }
        #endregion

        #region Sorted set POC
        static void sortedSetPOC()
        {
            var ss = new SortedSet<(int, int)>(new MyComparer());

            ss.Add((1, 5));
            ss.Add((2, 1));
            ss.Add((3, 4));
            ss.Add((4, 1));

            Console.WriteLine($"Max: {ss.Max}");
            Console.WriteLine($"Min: {ss.Min}");
            printSS(ss);
        }

        static void printSS(SortedSet<(int, int)> ss)
        {
            foreach (var s in ss)
            {
                Console.WriteLine($"{s.Item1}: {s.Item2}");
            }
        }
        #endregion
    }

    class MyComparer : IComparer<(int, int)>
    {
        public int Compare((int, int) x, (int, int) y)
        {
            if (x.Item2 != y.Item2)
                return x.Item2 - y.Item2;
            else
                return x.Item1 - y.Item1;

            // if (x.Item2 != y.Item2)
            //     return -(x.Item2 - y.Item2);
            // else
            //     return -(x.Item1 - y.Item1);
        }
    }
}
