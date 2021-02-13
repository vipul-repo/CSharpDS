using System;
using System.Collections.Generic;

class MinimumDeletionsInsertions
{
    public static void Main1()
    {
        var s1 = "zasdx";
        var s2 = "xqwasedr";

        var lcs = findLCS(s1, s2);
        Console.WriteLine($"LCS is: {lcs}");
        printMDI(s1, lcs);
        printMDI(s2, lcs);
    }

    static string findLCS(string s1, string s2)
    {
        if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2)) return "";

        var dp = new int[s1.Length + 1][];
        for (int i = 0; i < dp.Length; i++)
            dp[i] = new int[s2.Length + 1];

        int maxI = 0, maxj = 0, maxLength = 0;

        for (int i = 1; i < dp.Length; i++)
        {
            for (int j = 1; j < dp[0].Length; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                else
                    dp[i][j] = Math.Max(dp[i][j - 1], dp[i - 1][j]);

                if (dp[i][j] > maxLength)
                {
                    maxLength = dp[i][j];
                    maxI = i;
                    maxj = j;
                }
            }
        }

        var lcs = new List<char>();

        while (dp[maxI][maxj] > 0)
        {
            lcs.Add(s1[maxI - 1]);

            maxI = maxI - 1;
            maxj = maxj - 1;
        }

        lcs.Reverse();

        return new string(lcs.ToArray());
    }

    static void printMDI(string s, string lcs)
    {
        var diff = s.Length - lcs.Length;

        if (diff < 0)
            Console.WriteLine($"Add {Math.Abs(diff)} characters from {s}");
        else if (diff > 0)
            Console.WriteLine($"Remove {Math.Abs(diff)} characters from {s}");
    }
}