using System;
using System.Collections.Generic;

class CanSumUnique
{
    public static void Main1()
    {
        var arr = new int[] { 1, 3, 4, 5 };
        var sum = 7;
        Console.WriteLine(canSum(arr, sum));

        Console.WriteLine("-----------------");

        arr = new int[] { 4, 5, 1 };
        sum = 7;
        Console.WriteLine(canSum(arr, sum));
    }

    static bool canSum(int[] arr, int sum)
    {
        var memo = new int[arr.Length];
        memo[arr.Length - 1] = arr[arr.Length - 1];

        for (int i = arr.Length - 2; i >= 0; i--)
        {
            memo[i] = arr[i] + memo[i + 1];
        }

        return canSum(arr, sum, 0, memo);
    }

    static bool canSum(int[] arr, int sum, int index, int[] memo)
    {
        if (sum == 0)
            return true;

        if (sum < 0 || index >= arr.Length)
            return false;

        var key = $"{sum}-{index}";

        if (sum > memo[index])
            return false;

        if (canSum(arr, sum - arr[index], index + 1, memo))
            return true;

        return canSum(arr, sum, index + 1, memo);
    }
}