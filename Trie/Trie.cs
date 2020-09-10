using System;
using System.Collections.Generic;

namespace CSharpDS
{
    class Trie
    {
        private class TrieNode
        {
            public Dictionary<char, TrieNode> children;
            public bool endOfWord;

            public TrieNode()
            {
                children = new Dictionary<char, TrieNode>();
                endOfWord = false;
            }
        }

        // check const
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode current = root;

            foreach (char c in word)
            {
                current.children.TryGetValue(c, out TrieNode node);

                if (node == null)
                {
                    node = new TrieNode();
                    current.children.Add(c, node);
                }

                current = node;
            }

            current.endOfWord = true;
        }

        public bool Search(string word)
        {
            TrieNode current = root;

            foreach (char c in word)
            {
                current.children.TryGetValue(c, out TrieNode node);

                if (node == null)
                    return false;

                current = node;
            }

            return current.endOfWord;
        }

        public void Delete(string word)
        {
            Delete(root, word, 0);
        }

        private bool Delete(TrieNode current, string word, int index)
        {
            if (index == word.Length)
            {
                if (!current.endOfWord)
                    return false;

                current.endOfWord = false;

                return current.children.Count == 0;
            }

            current.children.TryGetValue(word[index], out TrieNode node);

            if (node == null)
                return false;

            bool shouldDelete = Delete(node, word, index + 1);

            if (shouldDelete)
            {
                current.children.Remove(word[index]);

                return current.children.Count == 0;
            }

            return false;
        }
    }
}