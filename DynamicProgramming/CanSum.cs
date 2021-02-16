using System;
using System.Collections.Generic;

class CanSum
{
    public static void Main1()
    {
        var arr = new int[] { 3, 7, 9, 5 };
        var sum = 15;
        var memo = new Dictionary<int, bool>();

        Console.WriteLine(canSum(arr, sum, memo));

        arr = new int[] { 7, 14 };
        sum = 300;
        memo = new Dictionary<int, bool>();

        Console.WriteLine(canSum(arr, sum, memo));
    }

    static bool canSum(int[] arr, int sum, Dictionary<int, bool> memo)
    {
        if (sum < 0)
            return false;

        if (sum == 0)
            return true;

        if (memo.ContainsKey(sum))
            return memo[sum];

        for (int i = 0; i < arr.Length; i++)
        {
            if (canSum(arr, sum - arr[i], memo))
            {
                memo[sum] = true;
                return memo[sum];
            }
        }

        memo[sum] = false;
        return memo[sum];
    }
}