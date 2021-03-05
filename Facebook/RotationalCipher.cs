using System;

// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to
public class RotationalCipher
{
    public static void Main1()
    {
        string input;
        int rotationFactor;

        input = "Zebra-493?";
        rotationFactor = 3;
        Console.WriteLine(rotationalCipher(input, rotationFactor));
        Console.WriteLine("Cheud-726?");


        input = "abcdefghijklmNOPQRSTUVWXYZ0123456789";
        rotationFactor = 39;
        Console.WriteLine(rotationalCipher(input, rotationFactor));
        Console.WriteLine("nopqrstuvwxyzABCDEFGHIJKLM9012345678");
    }

    private static string rotationalCipher(String input, int rotationFactor)
    {
        var cipher = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            int newAsci;

            if ('A' <= input[i] && input[i] <= 'Z')
            {
                newAsci = ((input[i] - 'A' + rotationFactor) % 26) + 'A';
            }
            else if ('a' <= input[i] && input[i] <= 'z')
            {
                newAsci = (char)((input[i] - 'a' + rotationFactor) % 26) + 'a';
            }
            else if ('0' <= input[i] && input[i] <= '9')
            {
                newAsci = (char)((input[i] - '0' + rotationFactor) % 10) + '0';
            }
            else
            {
                newAsci = input[i];
            }

            cipher[i] = (char)newAsci;
        }

        return new string(cipher);
    }
}