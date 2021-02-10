using System;
using System.Collections.Generic;

class NodesInASubtree
{
    public static void Main1()
    {
        string s = "aba";

        var root = new Node(1);
        root.childrens.Add(new Node(2));
        root.childrens.Add(new Node(3));

        var queries = new List<(int, char)>();
        queries.Add((1, 'a'));
        queries.Add((2, 'a'));
        queries.Add((3, 'a'));

        var result = countOfNodes(root, queries, s);

        Console.WriteLine($"[{string.Join(", ", result)}]");
    }

    static int[] countOfNodes(Node root, List<(int, char)> queries, string s)
    {
        var treeMap = new Dictionary<int, Dictionary<char, int>>();
        countNodeMap(root, s, treeMap);

        List<int> result = new List<int>();

        foreach (var query in queries)
        {
            if (treeMap.ContainsKey(query.Item1) && treeMap[query.Item1].ContainsKey(query.Item2))
                result.Add(treeMap[query.Item1][query.Item2]);
            else
                result.Add(0);
        }

        return result.ToArray();
    }

    static Dictionary<char, int> countNodeMap(Node root, string s, Dictionary<int, Dictionary<char, int>> treeMap)
    {
        var nodeMap = new Dictionary<char, int>();
        treeMap.Add(root.value, nodeMap);

        nodeMap.Add(s[root.value - 1], 1);

        foreach (var child in root.childrens)
        {
            var childMap = countNodeMap(child, s, treeMap);

            foreach (var kv in childMap)
            {
                if (nodeMap.ContainsKey(kv.Key))
                    nodeMap[kv.Key]++;
                else
                    nodeMap.Add(kv.Key, kv.Value);
            }
        }

        return nodeMap;
    }

    class Node
    {
        public int value;
        public List<Node> childrens;

        public Node(int value)
        {
            this.value = value;
            childrens = new List<Node>();
        }
    }
}
