using System.Collections.Generic;

class FibProblem
{
    public static long Fib(int num, Dictionary<int, long> memo = null)
    {
        if (memo == null) memo = new Dictionary<int, long>();
        if (memo.ContainsKey(num)) return memo[num];
        if (num <= 2) return 1;

        memo[num] = Fib(num - 1, memo) + Fib(num - 2, memo);

        return memo[num];
    }
}