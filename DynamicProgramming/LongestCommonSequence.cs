using System;
using System.Collections.Generic;

class LongestCommonSequence
{
    public static void Main1()
    {
        string s1 = "abcdaf";
        string s2 = "acbcf";

        Console.WriteLine(commonSequence(s1, s2));
    }

    static string commonSequence(string s1, string s2)
    {
        if (s1 == null || s2 == null) return "";

        int len1 = s1.Length;
        int len2 = s2.Length;

        if (len1 == 0 || len2 == 0) return "";

        // initialize empty array to hold sequence
        var dp = new int[len1 + 1][];
        for (int i = 0; i < len1 + 1; i++)
        {
            dp[i] = new int[len2 + 1];
        }


        for (int i = 1; i < len1 + 1; i++)
        {
            for (int j = 1; j < len2 + 1; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                }
                else
                {
                    dp[i][j] = Math.Max(dp[i][j - 1], dp[i - 1][j]);
                }
            }
        }

        return generateString(dp, s1, s2);
    }

    static string generateString(int[][] dp, string s1, string s2)
    {
        int i = dp.Length - 1, j = dp[0].Length - 1;

        var chars = new char[dp[i][j]];
        var charIndex = dp[i][j] - 1;

        while (dp[i][j] != 0)
        {
            if (dp[i][j] == dp[i][j - 1])
            {
                j--;
            }
            else if (dp[i][j] == dp[i - 1][j])
            {
                i--;
            }
            else
            {
                chars[charIndex] = s1[i - 1];
                charIndex--;

                i--;
                j--;
            }
        }

        return new string(chars);
    }
}