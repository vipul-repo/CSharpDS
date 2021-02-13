using System;
using System.Collections.Generic;

class LongestCommonSubstring1
{
    public static void Main1()
    {
        var s1 = "zasdx";
        var s2 = "qwasedr";

        Console.WriteLine(findLCSLengthTD(s1, s2));
        Console.WriteLine(findLCSLengthBU(s1, s2));
        Console.WriteLine(findLCSLengthBU1(s1, s2));
    }

    static int findLCSLengthTD(string s1, string s2)
    {
        if (s1 == null || s2 == null)
            return 0;

        var dp = new Dictionary<string, int>();
        var chars = new List<char>();

        var result = findLCSLengthTD(s1, s2, 0, 0, 0, dp, chars);

        // Console.WriteLine(new string(chars.ToArray()));

        return result;
    }

    static int findLCSLengthTD(string s1, string s2, int i1, int i2, int length, Dictionary<string, int> dp, List<char> chars)
    {
        if (i1 == s1.Length || i2 == s2.Length)
        {
            chars.Add('#');
            return length;
        }

        var key = $"{i1}|{i2}|{length}";

        if (!dp.ContainsKey(key))
        {
            var l1 = length;
            if (s1[i1] == s2[i2])
            {
                chars.Add(s1[i1]);
                l1 = findLCSLengthTD(s1, s2, i1 + 1, i2 + 1, length + 1, dp, chars);
            }

            var l2 = findLCSLengthTD(s1, s2, i1, i2 + 1, 0, dp, chars);
            var l3 = findLCSLengthTD(s1, s2, i1 + 1, i2, 0, dp, chars);

            dp[key] = Math.Max(l1, Math.Max(l2, l3));
        }

        return dp[key];
    }

    static int findLCSLengthBU(string s1, string s2)
    {
        if (s1 == null || s2 == null)
            return 0;

        var dp = new int[s1.Length + 1][];

        for (int i = 0; i < dp.Length; i++)
            dp[i] = new int[s2.Length + 1];

        var maxLength = 0;

        for (int i = 1; i <= s1.Length; i++)
        {
            for (int j = 1; j <= s2.Length; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                    dp[i][j] = dp[i - 1][j - 1] + 1;
                else
                    dp[i][j] = 0;

                maxLength = Math.Max(maxLength, dp[i][j]);
            }
        }

        // for (int i = 0; i < dp.Length; i++)
        //     Console.WriteLine(string.Join(", ", dp[i]));

        return maxLength;
    }

    static int findLCSLengthBU1(string s1, string s2)
    {
        if (s1 == null || s2 == null)
            return 0;

        var dp = new int[s2.Length + 1];

        var maxLength = 0;

        for (int i = 1; i <= s1.Length; i++)
        {
            var dpi = new int[s2.Length + 1];

            for (int j = 1; j <= s2.Length; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                    dpi[j] = dp[j - 1] + 1;
                else
                    dpi[j] = 0;

                maxLength = Math.Max(maxLength, dpi[j]);
            }

            // Console.WriteLine(string.Join(", ", dpi));
            dp = dpi;
        }

        return maxLength;
    }
}