using System;
using System.Collections.Generic;

namespace CSharpDS
{
    class DistinctCharacterSubstringProblem
    {
        public string[] UniqueSubstring(string s, int k)
        {
            if (k > s.Length)
                return new string[] { };

            int start = 0, current = 0;

            HashSet<string> subStrings = new HashSet<string>();
            HashSet<char> chars = new HashSet<char>();

            for (current = 0; current < s.Length; current++)
            {
                var charAdded = chars.Add(s[current]);

                if (!charAdded)
                {
                    while (s[start] != s[current])
                    {
                        chars.Remove(s[start]);
                        start++;
                    }

                    start++;
                }
                else if (current - start == k - 1)
                {
                    subStrings.Add(s.Substring(start, k));
                    chars.Remove(s[start]);
                    start++;
                }
            }

            var arr = new string[subStrings.Count];

            subStrings.CopyTo(arr);

            return arr;
        }
    }
}