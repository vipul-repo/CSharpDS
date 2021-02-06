using System;

// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
class SeatingArrangements
{
    static void Main1(string[] args)
    {
        var arr = new int[] { 5, 10, 6, 8 };
        Console.WriteLine(minOverallAwkwardness(arr));

        arr = new int[] { };
        Console.WriteLine(minOverallAwkwardness(arr));

        arr = new int[] { 5, 10, 6, 8, 4, 2, 6, 9 };
        Console.WriteLine(minOverallAwkwardness(arr));
    }

    private static int minOverallAwkwardness(int[] arr)
    {
        if (arr == null || arr.Length == 0) return 0;

        if (arr.Length < 3)
        {
            return calculateMinOverallAkwardness(arr);
        }
        else
        {
            arr = arrangeGuest(arr);
            return calculateMinOverallAkwardness(arr);
        }
    }

    private static int[] arrangeGuest(int[] arr)
    {
        Array.Sort(arr);

        int[] table = new int[arr.Length];

        int left = 0;
        int right = arr.Length - 1;

        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
            {
                table[left] = arr[i];
                left++;
            }
            else if (i % 2 != 0)
            {
                table[right] = arr[i];
                right--;
            }
        }

        return table;
    }

    private static int calculateMinOverallAkwardness(int[] arr)
    {
        var akwardness = Math.Abs(arr[0] - arr[arr.Length - 1]);

        for (int i = 0; i < arr.Length - 1; i++)
        {
            akwardness = Math.Max(akwardness, Math.Abs(arr[i] - arr[i + 1]));
        }

        return akwardness;
    }
}