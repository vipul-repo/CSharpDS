using System;
using System.Collections.Generic;

class SchoolBookSum
{
    public static void Main1()
    {
        var a = new int[] { 1, 0 };
        var b = new int[] { 1, 0, 0, 0, };

        Console.WriteLine(string.Join(null, Sum(a, b)));
    }

    static List<int> Sum(int[] a, int[] b)
    {
        var res = new List<int> { };
        Array.Reverse(a);
        Array.Reverse(b);
        int aLength = a.Length;
        int bLength = b.Length;
        int length = Math.Max(aLength, bLength);

        int carry = 0;

        for (int i = 0; i < length; i++)
        {
            var sum = carry + (i < aLength ? a[i] : 0) + (i < bLength ? b[i] : 0);

            res.Add(sum % 10);
            carry = sum / 10;
        }

        if (carry > 0)
            res.Add(carry);

        res.Reverse();
        return res;
    }
}