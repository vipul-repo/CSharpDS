using System;
using System.Collections.Generic;

namespace CSharpDS
{
    class TopMentionedWords
    {
        public List<string> GetTopMentionedWords(int topNWords, List<string> words, List<string> reviews)
        {
            List<string> result = new List<string>();

            if (topNWords <= 0 || words.Count == 0 || reviews.Count == 0)
                return result;

            var reviewWordIndex = GenerateReviewIndex(reviews);

            SortedSet<Word> mentionList = new SortedSet<Word>(new FrequencyComparer());

            foreach (var competitor in words)
            {
                if (reviewWordIndex.TryGetValue(competitor.ToLower(), out int mention))
                {
                    mentionList.Add(new Word(competitor, mention));
                }
            }

            for (int i = 0; i < topNWords; i++)
            {
                var max = mentionList.Max;

                if (max == null)
                    break;

                result.Add(max.value);
                mentionList.Remove(max);
            }

            return result;
        }

        private Dictionary<string, int> GenerateReviewIndex(List<string> reviews)
        {
            Dictionary<string, int> reviewWordIndex = new Dictionary<string, int>();

            foreach (var review in reviews)
            {
                Dictionary<string, int> uniqueWordIndex = new Dictionary<string, int>();

                var words = review.ToLower().Split(new Char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (word.StartsWith("\"") && word.EndsWith("\""))
                    {
                        var addWord = word.Replace("\"", "");

                        if (!reviewWordIndex.TryAdd(addWord, 1))
                        {
                            reviewWordIndex[addWord]++;
                        }
                    }
                    else
                    {
                        var addWord = word.Replace("\"", "");
                        uniqueWordIndex.TryAdd(addWord, 1);
                    }
                }

                foreach (var word in uniqueWordIndex.Keys)
                {
                    if (!reviewWordIndex.TryAdd(word, 1))
                    {
                        reviewWordIndex[word]++;
                    }
                }
            }

            return reviewWordIndex;
        }
    }

    class Word
    {
        public string value { get; }
        public int mention { get; }

        public Word(string value, int mention)
        {
            this.value = value;
            this.mention = mention;
        }
    }

    class FrequencyComparer : IComparer<Word>
    {
        public int Compare(Word x, Word y)
        {
            return x.mention - y.mention != 0 ? x.mention - y.mention : y.value.CompareTo(x.value);
        }
    }
}