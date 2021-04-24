using System;
using System.Collections.Generic;

class IsBinaryTree
{
    public static void Main1()
    {
        var root = new Node(4);

        root.left = new Node(2);
        root.left.left = new Node(1);
        root.left.right = new Node(3);

        root.right = new Node(6);
        root.right.left = new Node(5);
        root.right.right = new Node(7);

        Console.WriteLine(checkBST(root));
        Console.WriteLine(checkBST1(root));

        root = new Node(3);

        root.left = new Node(2);
        root.left.left = new Node(1);

        root.right = new Node(5);
        root.right.left = new Node(6);
        root.right.right = new Node(1);

        Console.WriteLine(checkBST(root));
        Console.WriteLine(checkBST1(root));
    }

    static bool checkBST1(Node root)
    {
        if (root == null) return false;

        var inOrder = new List<int>();

        inOrderTravel(root, inOrder);

        for (int i = 0; i < inOrder.Count - 1; i++)
        {
            if (inOrder[i] >= inOrder[i + 1])
                return false;
        }

        return true;
    }

    static void inOrderTravel(Node root, List<int> inOrder)
    {
        if (root == null) return;

        inOrderTravel(root.left, inOrder);
        inOrder.Add(root.data);
        inOrderTravel(root.right, inOrder);
    }

    static bool checkBST(Node root)
    {
        var values = new HashSet<int>();

        return checkBST(root, values).isBst;
    }

    static (bool isBst, int minValue, int maxValue) checkBST(Node root, HashSet<int> values)
    {
        if (root == null)
            return (true, int.MaxValue, int.MinValue);

        if (values.Contains(root.data))
            return (false, 0, 0);

        values.Add(root.data);

        var leftBST = checkBST(root.left, values);

        if (!leftBST.isBst || !(root.data > leftBST.maxValue))
            return (false, 0, 0);

        var rightBST = checkBST(root.right, values);

        if (!rightBST.isBst || !(root.data < rightBST.minValue))
            return (false, 0, 0);

        return (true,
        Math.Min(root.data, leftBST.minValue),
        Math.Max(root.data, rightBST.maxValue));
    }

    class Node
    {
        public Node(int data)
        {
            this.data = data;
        }

        public int data { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
    }
}