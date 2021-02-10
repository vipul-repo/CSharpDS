using System;
using System.Collections.Generic;
using System.Linq;

class LogenstCommonElementSeauence
{
    public static void Main1(String[] args)
    {
        String[] user0 = { "/start", "/green", "/blue", "/pink", "/register", "/orange", "/one", "/two" };
        String[] user1 = { "/start", "/pink", "/register", "/orange", "/red", "a" };
        String[] user2 = { "a", "/one", "/two" };
        String[] user3 = { "/pink", "/orange", "/yellow", "/plum", "/blue", "/tan", "/red", "/amber", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow", "/BritishRacingGreen" };
        String[] user4 = { "/pink", "/orange", "/amber", "/BritishRacingGreen", "/plum", "/blue", "/tan", "/red", "/lavender", "/HotRodPink", "/CornflowerBlue", "/LightGoldenRodYellow" };
        String[] user5 = { "a" };
        String[] user6 = { "/pink", "/orange", "/six", "/plum", "/seven", "/tan", "/red", "/amber" };

        List<string> result = null;
        result = findContiguousHistory(user0, user1);
        Console.WriteLine(string.Join(", ", result));
        result = findContiguousHistory1(user0, user1);
        Console.WriteLine(string.Join(", ", result));
        Console.WriteLine("==================================");
        result = findContiguousHistory(user0, user2);
        Console.WriteLine(string.Join(", ", result));
        result = findContiguousHistory1(user0, user2);
        Console.WriteLine(string.Join(", ", result));
        Console.WriteLine("==================================");
        result = findContiguousHistory(user3, user4);
        Console.WriteLine(string.Join(", ", result));
        result = findContiguousHistory1(user3, user4);
        Console.WriteLine(string.Join(", ", result));
        Console.WriteLine("==================================");
        result = findContiguousHistory(user2, user5);
        Console.WriteLine(string.Join(", ", result));
        result = findContiguousHistory1(user2, user5);
        Console.WriteLine(string.Join(", ", result));
        Console.WriteLine("==================================");
        result = findContiguousHistory(user1, user5);
        Console.WriteLine(string.Join(", ", result));
        result = findContiguousHistory1(user1, user5);
        Console.WriteLine(string.Join(", ", result));
        Console.WriteLine("==================================");
        result = findContiguousHistory(user4, user6);
        Console.WriteLine(string.Join(", ", result));
        result = findContiguousHistory1(user4, user6);
        Console.WriteLine(string.Join(", ", result));
        Console.WriteLine("==================================");
    }

    static List<string> findContiguousHistory(string[] user1, string[] user2)
    {
        List<string> result = new List<string>();

        Dictionary<string, int> user1Dictionary = new Dictionary<string, int>();

        for (int i = 0; i < user1.Length; i++)
            user1Dictionary.Add(user1[i], i);

        for (int idx2 = 0; idx2 < user2.Length; idx2++)
        {
            if (user1Dictionary.ContainsKey(user2[idx2]))
            {
                var idx1 = user1Dictionary[user2[idx2]];

                var tempResult = getCommon(user1, idx1, user2, idx2);

                if (result.Count < tempResult.Count)
                    result = tempResult;
            }
        }

        return result;
    }

    private static List<string> getCommon(string[] user1, int idx1, string[] user2, int idx2)
    {
        List<string> tempResult = new List<string>();

        while (idx1 < user1.Length && idx2 < user2.Length && user1[idx1] == user2[idx2])
        {
            tempResult.Add(user2[idx2]);
            idx2++;
            idx1++;
        }

        return tempResult;
    }

    static List<string> findContiguousHistory1(string[] user1, string[] user2)
    {
        var length1 = user1.Length;
        var lenght2 = user2.Length;

        if (length1 == 0 || lenght2 == 0)
            return new List<string>();

        int[][] dp = new int[length1 + 1][];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[lenght2 + 1];
        }

        for (int i = 1; i < length1 + 1; i++)
        {
            for (int j = 1; j < lenght2 + 1; j++)
            {
                if (user1[i - 1] == user2[j - 1])
                {
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                }
                else
                {
                    dp[i][j] = 0;
                }
            }
        }

        int maxLength = 0;
        int maxI = 0;
        int maxJ = 0;

        for (int i = 0; i < dp.Length; i++)
        {
            for (int j = 0; j < dp[i].Length; j++)
            {
                if (dp[i][j] > maxLength)
                {
                    maxLength = dp[i][j];
                    maxI = i;
                    maxJ = j;
                }
            }
        }

        List<string> result = new List<string>();
        while (dp[maxI][maxJ] > 0)
        {
            result.Add(user1[maxI - 1]);
            maxI--;
            maxJ--;
        }

        result.Reverse();

        return result;
    }
}