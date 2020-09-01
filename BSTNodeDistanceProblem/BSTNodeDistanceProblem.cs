using System;

namespace CSharpDS
{
    class BSTNodeDistanceProblem
    {
        public int GetDistance(int[] nums, int node1, int node2)
        {
            if (nums.Length == 0)
                return -1;

            if (node1 == node2)
                return 0;

            var root = GenerateBST(nums);

            var lastCommonNode = GetLowestCommonNode(root, node1, node2);

            if (lastCommonNode == null)
                return -1;

            var node1Dist = GetDistance(lastCommonNode, node1, 0);
            var node2Dist = GetDistance(lastCommonNode, node2, 0);

            return node1Dist == -1 || node2Dist == -1 ? -1 : node1Dist + node2Dist;
        }

        private int GetDistance(Node node, int value, int dist)
        {
            if (node == null)
                return -1;
            else if (node.value == value)
                return dist;
            else if (node.value > value)
                return GetDistance(node.left, value, dist + 1);
            else
                return GetDistance(node.right, value, dist + 1);

        }

        private Node GetLowestCommonNode(Node root, int node1, int node2)
        {
            if (root == null || root.value == node1 || root.value == node2)
                return root;
            if (node1 < root.value && node2 < root.value)
                return GetLowestCommonNode(root.left, node1, node2);
            else if (node1 > root.value && node2 > root.value)
                return GetLowestCommonNode(root.right, node1, node2);
            else
                return root;
        }

        private Node GenerateBST(int[] nums)
        {
            if (nums.Length == 0)
                return null;

            var root = new Node(nums[0]);

            for (int i = 1; i < nums.Length; i++)
            {
                InsertNode(root, nums[i]);
            }

            return root;
        }

        private void InsertNode(Node root, int value)
        {
            if (root == null)
                return;

            if (value < root.value)
            {
                if (root.left == null)
                    root.left = new Node(value);
                else
                    InsertNode(root.left, value);
            }
            else
            {
                if (root.right == null)
                    root.right = new Node(value);
                else
                    InsertNode(root.right, value);
            }

        }
    }

}