using System;
using System.Collections.Generic;

namespace CSharpDS
{
    class MostCommonWordProblem
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            var paragraphWords = paragraph.Split(new string[] { " ", "!", "?", "'", ",", ";", "." }, StringSplitOptions.RemoveEmptyEntries);

            var paragraphDictionary = new Dictionary<string, int>();

            foreach (var word in paragraphWords)
            {
                var wordLower = word.ToLower();

                if (!paragraphDictionary.TryAdd(wordLower, 1))
                {
                    paragraphDictionary[wordLower]++;
                }
            }

            var sortedParagraphDictionary = new SortedSet<ParaWord>(new ParaWordComparer());

            foreach (var pair in paragraphDictionary)
            {
                sortedParagraphDictionary.Add(new ParaWord(pair.Key, pair.Value));
            }

            string result = null;

            while (sortedParagraphDictionary.Count > 0 && result == null)
            {
                var word = sortedParagraphDictionary.Max;
                sortedParagraphDictionary.Remove(word);

                if (!Array.Exists(banned, i => i == word.Text))
                {
                    result = word.Text;
                }
            }

            return result;
        }
    }

    class ParaWord
    {
        public string Text { get; private set; }
        public int Count { get; private set; }

        public ParaWord(string text, int count)
        {
            Text = text;
            Count = count;
        }
    }

    class ParaWordComparer : IComparer<ParaWord>
    {
        public int Compare(ParaWord x, ParaWord y)
        {
            var result = x.Count.CompareTo(y.Count);

            if (result != 0)
                return result;

            return y.Text.CompareTo(x.Text);
        }
    }
}