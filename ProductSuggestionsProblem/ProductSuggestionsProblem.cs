using System;
using System.Collections.Generic;

namespace CSharpDS
{
    class ProductSuggestionsProblem
    {
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            TriePS trie = new TriePS(3);

            Array.Sort(products);

            foreach (string product in products)
            {
                trie.Insert(product);
            }

            var result = trie.Search(searchWord);

            while (result.Count < searchWord.Length)
                result.Add(new List<string>());

            return result;
        }
    }

    class TrieNodePS
    {
        public Dictionary<char, TrieNodePS> children
        {
            get;
            private set;
        }

        public List<string> suggestions
        {
            get;
            private set;
        }

        public TrieNodePS()
        {
            children = new Dictionary<char, TrieNodePS>();
            suggestions = new List<string>();
        }
    }

    class TriePS
    {
        private TrieNodePS root;
        private int suggestionsLength;

        public TriePS(int suggestionsLength)
        {
            this.suggestionsLength = suggestionsLength;
            root = new TrieNodePS();
        }

        public void Insert(string word)
        {
            TrieNodePS current = root;

            foreach (char c in word)
            {
                current.children.TryGetValue(c, out TrieNodePS node);

                if (node == null)
                {
                    node = new TrieNodePS();
                    current.children.Add(c, node);
                }

                if (node.suggestions.Count < suggestionsLength)
                {
                    node.suggestions.Add(word);
                }

                current = node;
            }
        }

        public IList<IList<string>> Search(string searchWord)
        {
            IList<IList<string>> result = new List<IList<string>>();

            TrieNodePS current = root;

            foreach (char c in searchWord)
            {
                current.children.TryGetValue(c, out TrieNodePS node);

                if (node == null)
                    break;

                result.Add(node.suggestions);

                current = node;
            }

            return result;
        }
    }
}