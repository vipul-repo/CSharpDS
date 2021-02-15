using System;
using System.Collections.Generic;

class LongestPalindrome
{
    public static void Main1()
    {
        var str = "qqqqaqwaeratyauiaqwazxacvabnamla";

        Console.WriteLine($"Length: {str.Length}");
        Console.WriteLine($"Palindrom Seq: {getLPSeq(str)}");
        Console.WriteLine($"Palindrom Seq: {getLPSeqString(str)}");
        Console.WriteLine($"Palindrom Sub: {getLPSub(str)}");
        Console.WriteLine($"Palindrom Sub: {getLPSubString(str)}");
    }

    static int getLPSeq(string str)
    {
        var memo = new Dictionary<string, int>();
        return getLPSeq(str, 0, str.Length - 1, memo);
    }

    static int getLPSeq(string str, int startIndex, int endIndex, Dictionary<string, int> memo)
    {
        if (startIndex > endIndex)
            return 0;

        if (startIndex == endIndex)
            return 1;

        var key = $"{startIndex}-{endIndex}";

        if (!memo.ContainsKey(key))
        {
            if (str[startIndex] == str[endIndex])
            {
                memo[key] = 2 + getLPSeq(str, startIndex + 1, endIndex - 1, memo);
            }
            else
            {
                var l1 = getLPSeq(str, startIndex + 1, endIndex, memo);
                var l2 = getLPSeq(str, startIndex, endIndex - 1, memo);

                memo[key] = Math.Max(l1, l2);
            }
        }

        return memo[key];
    }

    static string getLPSeqString(string str)
    {
        var memo = new Dictionary<string, string>();
        return getLPSeqString(str, 0, str.Length - 1, memo);
    }

    static string getLPSeqString(string str, int startIndex, int endIndex, Dictionary<string, string> memo)
    {
        if (startIndex > endIndex)
            return "";

        if (startIndex == endIndex)
            return str.Substring(startIndex, 1);

        var key = $"{startIndex}-{endIndex}";

        if (!memo.ContainsKey(key))
        {
            if (str[startIndex] == str[endIndex])
            {
                memo[key] = $"{str.Substring(startIndex, 1)}{getLPSeqString(str, startIndex + 1, endIndex - 1, memo)}{str.Substring(endIndex, 1)}";
            }
            else
            {
                var str1 = getLPSeqString(str, startIndex + 1, endIndex, memo);
                var str2 = getLPSeqString(str, startIndex, endIndex - 1, memo);

                memo[key] = str1.Length > str2.Length ? str1 : str2;
            }
        }

        return memo[key];
    }

    static int getLPSub(string str)
    {
        var memo = new Dictionary<string, int>();
        return getLPSub(str, 0, str.Length - 1, memo);
    }

    static int getLPSub(string str, int startIndex, int endIndex, Dictionary<string, int> memo)
    {
        if (startIndex > endIndex)
            return 0;

        if (startIndex == endIndex)
            return 1;

        var key = $"{startIndex}-{endIndex}";

        if (!memo.ContainsKey(key))
        {
            if (str[startIndex] == str[endIndex])
            {
                var remLength = endIndex - startIndex - 1;

                if (remLength == getLPSub(str, startIndex + 1, endIndex - 1, memo))
                {
                    memo[key] = 2 + remLength;
                    return memo[key];
                }
            }

            var l1 = getLPSub(str, startIndex + 1, endIndex, memo);
            var l2 = getLPSub(str, startIndex, endIndex - 1, memo);

            memo[key] = Math.Max(l1, l2);
        }

        return memo[key];
    }

    static string getLPSubString(string str)
    {
        var memo = new Dictionary<string, string>();
        return getLPSubString(str, 0, str.Length - 1, memo);
    }

    static string getLPSubString(string str, int startIndex, int endIndex, Dictionary<string, string> memo)
    {
        if (startIndex > endIndex)
            return "";

        if (startIndex == endIndex)
            return str.Substring(startIndex, 1);

        var key = $"{startIndex}-{endIndex}";

        if (!memo.ContainsKey(key))
        {
            if (str[startIndex] == str[endIndex])
            {
                var remLength = endIndex - startIndex - 1;
                var remPal = getLPSubString(str, startIndex + 1, endIndex - 1, memo);
                if (remLength == remPal.Length)
                {
                    memo[key] = $"{str.Substring(startIndex, 1)}{remPal}{str.Substring(endIndex, 1)}";
                    return memo[key];
                }
            }

            var str1 = getLPSubString(str, startIndex + 1, endIndex, memo);
            var str2 = getLPSubString(str, startIndex, endIndex - 1, memo);

            memo[key] = str1.Length > str2.Length ? str1 : str2;
        }

        return memo[key];
    }
}