using System;

class LongestIncreasingSubsequence
{
    public static void Main1()
    {
        var nums = new int[] { 5, 1, 4, 2, 3, 4, 5, 6, 2 };
        Console.WriteLine(getLIS(nums));
        // Console.WriteLine("--------------");
        Console.WriteLine(findMSIS(nums));
    }

    static int getLIS(int[] nums)
    {
        int maxLength = 0;

        var dp = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;

            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j] && dp[i] <= dp[j])
                {
                    dp[i] = 1 + dp[j];
                    maxLength = Math.Max(maxLength, dp[i]);
                }
            }
        }

        return maxLength;
    }

    static int findMSIS(int[] nums)
    {
        int maxSum = 0;

        var dp = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = nums[i];

            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j] && dp[i] < dp[j] + nums[i])
                {
                    dp[i] = nums[i] + dp[j];
                    maxSum = Math.Max(maxSum, dp[i]);
                }
            }
        }

        Console.WriteLine(string.Join(", ", dp));

        return maxSum;
    }

}