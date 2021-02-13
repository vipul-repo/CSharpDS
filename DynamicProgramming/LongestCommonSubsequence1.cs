using System;
using System.Collections.Generic;

class LongestCommonSubsequence1
{
    public static void Main1()
    {
        var s1 = "zasdx";
        var s2 = "xqwasedr";

        Console.WriteLine(findLCSLengthTD(s1, s2));
        Console.WriteLine(findLCSLengthBU(s1, s2));
    }

    static int findLCSLengthTD(string s1, string s2)
    {
        if (s1 == null || s2 == null) return 0;

        var memo = new Dictionary<string, int>();

        return findLCSLengthTD(s1, s2, 0, 0, memo);
    }

    static int findLCSLengthTD(string s1, string s2, int i1, int i2, Dictionary<string, int> memo)
    {
        if (i1 == s1.Length || i2 == s2.Length) return 0;

        var key = $"{i1}|{i2}";

        if (!memo.ContainsKey(key))
        {
            if (s1[i1] == s2[i2])
            {
                memo[key] = 1 + findLCSLengthTD(s1, s2, i1 + 1, i2 + 1, memo);
            }
            else
            {
                int l2 = findLCSLengthTD(s1, s2, i1, i2 + 1, memo);
                int l3 = findLCSLengthTD(s1, s2, i1 + 1, i2, memo);

                memo[key] = Math.Max(l2, l3);
            }
        }

        return memo[key];
    }

    static int findLCSLengthBU(string s1, string s2)
    {
        if (s1 == null || s2 == null) return 0;

        int maxLength = 0;

        var dp = new int[s1.Length + 1][];
        for (int i = 0; i < dp.Length; i++)
            dp[i] = new int[s2.Length + 1];

        for (int i = 1; i < dp.Length; i++)
        {
            for (int j = 1; j < dp[0].Length; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                else
                    dp[i][j] = Math.Max(dp[i][j - 1], dp[i - 1][j]);

                maxLength = Math.Max(maxLength, dp[i][j]);
            }
        }

        return maxLength;
    }
}