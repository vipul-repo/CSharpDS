using System;
using System.Collections.Generic;

class GridPath
{
    public static void Main1()
    {
        Console.WriteLine(numberOfPaths(3, 3)); //6
        Console.WriteLine(numberOfPaths(2, 8)); //8
    }

    static long numberOfPaths(int m, int n)
    {
        if (m < 1 || n < 1) return 0;

        if (m == 1 && n == 1) return 1;

        return numberOfPaths(m - 1, n) + numberOfPaths(m, n - 1);
    }
}