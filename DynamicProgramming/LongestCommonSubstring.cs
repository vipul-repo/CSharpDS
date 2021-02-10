using System;
using System.Collections.Generic;

class LongestCommonSubstring
{
    public static void Main1()
    {
        string s1 = "abcdaf";
        string s2 = "zbcdf";

        Console.WriteLine(commonSubstring(s1, s2));
    }

    static string commonSubstring(string s1, string s2)
    {
        if (s1 == null || s2 == null) return "";

        int m = s1.Length + 1;
        int n = s2.Length + 1;

        if (m == 1 || n == 1) return "";

        var dp = new int[m][];

        for (int i = 0; i < m; i++)
            dp[i] = new int[n];

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                else
                    dp[i][j] = 0;
            }
        }

        int mi = 0, ni = 0;
        int max = 0;

        for (int i = 1; i < m; i++)
            for (int j = 1; j < n; j++)
                if (dp[i][j] > max)
                {
                    max = dp[i][j];
                    mi = i;
                    ni = j;
                }

        var chars = new List<char>();

        while (dp[mi][ni] > 0)
        {
            chars.Add(s1[mi - 1]);
            mi--;
            ni--;
        }

        chars.Reverse();
        return new string(chars.ToArray());

    }
}