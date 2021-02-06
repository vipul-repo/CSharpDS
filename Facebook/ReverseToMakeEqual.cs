using System;

// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
class ReverseToMakeEqual
{
    static void Main1(string[] args)
    {
        int[] arr_a = new int[] { 1, 2, 3, 4 };
        int[] arr_b = new int[] { 1, 4, 3, 2 };
        // Call areTheyEqual() with test cases here
        Console.WriteLine(areTheyEqual(arr_a, arr_b));

        arr_a = new int[] { 1, 2, 3, 4, 5, 3 };
        arr_b = new int[] { 1, 4, 3, 2, 5, 3 };
        // Call areTheyEqual() with test cases here
        Console.WriteLine(areTheyEqual(arr_a, arr_b));

        arr_a = new int[] { 1, 2, 3, 4, 5, 4, 3 };
        arr_b = new int[] { 1, 4, 3, 2, 5, 5, 3 };
        // Call areTheyEqual() with test cases here
        Console.WriteLine(areTheyEqual(arr_a, arr_b));
    }

    private static bool areTheyEqual(int[] arr_a, int[] arr_b)
    {
        if (arr_a.Length != arr_b.Length)
            return false;

        var left = -1;

        for (int i = 0; i < arr_a.Length; i++)
        {
            if (arr_a[i] != arr_b[i])
            {
                left = i;
                break;
            }
        }

        if (left == -1) return true;

        var right = -1;

        for (int i = arr_a.Length - 1; i >= 0; i--)
        {
            if (arr_a[i] != arr_b[i])
            {
                right = i;
                break;
            }
        }


        while (left <= right)
        {
            if (arr_a[left] != arr_b[right])
                return false;

            left++;
            right--;
        }

        return true;
        /*
        var left = 0;
        var right = arr_a.Length - 1;

        var leftMismatch = -1;
        var rightMismatch = -1;

        while(left <= right){
          if(leftMismatch == -1 && arr_a[left] != arr_b[left])
              leftMismatch = left;

          if(rightMismatch == -1 && arr_a[right] != arr_b[right])
              rightMismatch = right;

          if(leftMismatch != -1 && rightMismatch != -1)
            break;

          left++;
          right--;
        }  

        while(leftMismatch <= rightMismatch)
        {
          Console.WriteLine($"leftMismatch: {leftMismatch}; rightMismatch: {rightMismatch}");

          if(arr_a[leftMismatch] != arr_b[rightMismatch])
            return false;

          leftMismatch++;
          rightMismatch--;
        }

        return true;*/
    }
}