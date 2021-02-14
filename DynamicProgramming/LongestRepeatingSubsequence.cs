using System;

class LongestRepeatingSubsequence
{
    public static void Main1()
    {
        Console.WriteLine(findLRSLength("tomorrow"));
    }

    static int findLRSLength(string str)
    {
        int[][] dp = new int[str.Length + 1][];

        for (int i = 0; i < dp.Length; i++)
            dp[i] = new int[str.Length + 1];

        int maxLength = 0;

        // dp[i1][i2] will be storing the LRS up to str[0..i1-1][0..i2-1]
        // this also means that subsequences of length zero (first row and column of dp[][]),
        // will always have LRS of size zero.
        for (int i1 = 1; i1 <= str.Length; i1++)
        {
            for (int i2 = 1; i2 <= str.Length; i2++)
            {
                if (i1 != i2 && str[i1 - 1] == str[i2 - 1])
                    dp[i1][i2] = 1 + dp[i1 - 1][i2 - 1];
                else
                    dp[i1][i2] = Math.Max(dp[i1 - 1][i2], dp[i1][i2 - 1]);

                maxLength = Math.Max(maxLength, dp[i1][i2]);
            }

            Console.WriteLine(string.Join(", ", dp[i1]));
        }
        return maxLength;
    }
}