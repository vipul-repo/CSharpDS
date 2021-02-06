using System;
using System.Collections.Generic;
// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
class LargestTripleProducts
{
    static void Main1(string[] args)
    {
        var arr = new int[] { 1, 2, 3, 4, 5 };

        var result = findMaxProduct(arr);
        Console.WriteLine(string.Join(", ", result));

        arr = new int[] { 2, 1, 2, 1, 2 };
        var result1 = findMaxProduct(arr);
        Console.WriteLine(string.Join(", ", result1));
    }

    private static int[] findMaxProduct(int[] arr)
    {
        var result = new int[arr.Length];
        var ss = new SortedSet<(int, int)>(new MyComparer());

        for (int i = 0; i < arr.Length; i++)
        {
            insertToSet(ss, (i, arr[i]));

            if (i < 2)
                result[i] = -1;
            else
                result[i] = getIndexProduct(ss);
        }

        // Write your code here
        return result;
    }

    private static void insertToSet(SortedSet<(int, int)> ss, (int, int) item)
    {
        ss.Add(item);

        /*
        foreach(var s in ss){
          Console.WriteLine($"Index: {s.Item1}; Value: {s.Item2}");
        }
        Console.WriteLine("------------");
        */

        if (ss.Count > 3)
        {
            //Console.WriteLine($"Removing: {ss.Min}");
            ss.Remove(ss.Min);
        }
    }

    private static int getIndexProduct(SortedSet<(int, int)> ss)
    {
        var product = 1;

        foreach (var s in ss)
        {
            product *= s.Item2;
        }

        return product;
    }
}

class MyComparer : IComparer<(int, int)>
{
    public int Compare((int, int) x, (int, int) y)
    {
        if (x.Item2 != y.Item2)
            return x.Item2 - y.Item2;
        else
            return x.Item1 - y.Item1;
    }
}