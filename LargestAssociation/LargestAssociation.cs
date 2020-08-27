using System;
using System.Collections.Generic;

namespace CSharpDS
{
    class LargestAssociation
    {
        public List<String> largestItemAssociation(List<PairString> itemAssociation)
        {
            Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();

            foreach (var item in itemAssociation)
            {
                graph.TryAdd(item.first, new HashSet<string>());
                graph[item.first].Add(item.second);

                graph.TryAdd(item.second, new HashSet<string>());
                graph[item.second].Add(item.first);
            }

            HashSet<string> visited = new HashSet<string>();

            var longestPath = new List<string>();

            foreach (var vertex in graph.Keys)
            {
                var path = new List<string>();
                getPath(graph, visited, vertex, path);

                if (path.Count >= longestPath.Count)
                {
                    path.Sort();

                    if (compareList(longestPath, path) > 0)
                    {
                        longestPath = path;
                    }
                }
            }

            return longestPath;
        }

        private int compareList(List<string> list1, List<string> list2)
        {
            if (list1.Count > list2.Count)
                return -1;
            else if (list2.Count > list1.Count)
                return 1;
            else
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    var compareItem = list1[i].CompareTo(list2[i]);

                    if (compareItem == 0)
                        continue;
                    else
                        return compareItem;
                }

                return 0;
            }
        }

        private void getPath(Dictionary<string, HashSet<string>> graph, HashSet<string> visited, string vertex, List<string> path)
        {
            if (visited.Contains(vertex))
                return;

            visited.Add(vertex);
            path.Add(vertex);

            foreach (var pair in graph[vertex])
            {
                getPath(graph, visited, pair, path);
            }
        }
    }

    class PairString
    {
        public string first { get; private set; }
        public string second { get; private set; }

        public PairString(string first, string second)
        {
            this.first = first;
            this.second = second;
        }
    }
}