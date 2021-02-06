using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpDS
{
    class BasicTest
    {
        public static void StringAsArray()
        {
            var str = "This is a string";
            Console.WriteLine(str[1]);
        }

        public static void IntArray()
        {
            var arr = new int[5];
            arr[1] = 100;
            Console.WriteLine("Empty int array print");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public static void StringArray()
        {
            var arr = new string[5];
            arr[1] = "string 100";
            Console.WriteLine("Empty string array print");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] ?? "null");
            }
        }


        public static int binaryArrayToNumber()
        {
            var s = "string";

            foreach (var c in s)
            {

            }

            var stack = new Stack<char>();

            if (stack.TryPop(out char sc))
            {
                if (sc == 'a')
                    return 1;
            }

            return 1;
        }

    }
}
