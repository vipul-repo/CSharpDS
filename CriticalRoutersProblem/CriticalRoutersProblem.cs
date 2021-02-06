using System;
using System.Collections.Generic;

namespace CSharpDS
{
    class CriticalRoutersProblem
    {
        public CriticalRoutersProblem()
        {

        }

        public List<int> getCriticalNodes(int[][] links)
        {
            List<int> points = new List<int>();
            Dictionary<int, HashSet<int>> map = createGraph(links);
            HashSet<int> visited = new HashSet<int>();
            Dictionary<int, int> timeToVisit = new Dictionary<int, int>();
            Dictionary<int, int> lowTimetToVisit = new Dictionary<int, int>();
            Dictionary<int, int> parent = new Dictionary<int, int>();

            foreach (var kv in map)
            {
                if (!visited.Contains(kv.Key))
                {
                    DFS(points, map, kv.Key, 0, visited, timeToVisit, lowTimetToVisit, parent);
                }
            }

            return null;
        }

        private Dictionary<int, HashSet<int>> createGraph(int[][] links)
        {
            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < links.Length; i++)
            {
                map.TryAdd(links[i][0], new HashSet<int>());
                map[links[i][0]].Add(links[i][1]);

                map.TryAdd(links[i][1], new HashSet<int>());
                map[links[i][1]].Add(links[i][0]);
            }

            return map;
        }

        private void DFS(List<int> points,
            Dictionary<int, HashSet<int>> graph,
            int vertex,
            int time,
            HashSet<int> visited,
            Dictionary<int, int> timeToVisit,
            Dictionary<int, int> lowTimetToVisit,
            Dictionary<int, int> parent)
        {
            visited.Add(vertex);
            graph.TryGetValue(vertex, out HashSet<int> adjVertices);

            foreach (int adj in adjVertices)
            {

            }
        }
    }
}