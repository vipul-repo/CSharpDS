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

            Dictionary<string, int> reviewWordIndex = new Dictionary<string, int>();

            GenerateReviewIndex(reviewWordIndex, reviews);

            List<Word> mentionList = new List<Word>();

            foreach (var competitor in words)
            {
                if (reviewWordIndex.TryGetValue(competitor.ToLower(), out int mention))
                {
                    mentionList.Add(new Word(competitor, mention));
                }
            }

            mentionList.Sort((x, y) =>
            {
                var mentionResult = y.mention - x.mention;

                if (mentionResult != 0)
                    return mentionResult;

                return x.value.CompareTo(y.value);
            });

            for (int i = 0; i < topNWords && i < mentionList.Count; i++)
            {
                result.Add(mentionList[i].value);
            }

            return result;
        }

        private void GenerateReviewIndex(Dictionary<string, int> reviewWordIndex, List<string> reviews)
        {
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
}