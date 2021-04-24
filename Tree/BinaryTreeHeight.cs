using System;
using System.Collections.Generic;

class BinaryTreeHeight
{
    public static void Main1()
    {
        var root = new Node(3);

        root.left = new Node(2);
        root.left.left = new Node(1);

        root.right = new Node(5);
        root.right.left = new Node(4);
        root.right.right = new Node(6);
        root.right.right.right = new Node(7);

        Console.WriteLine(height(root));
    }

    static int height(Node root)
    {
        if (root == null) return 0;

        return 1 + Math.Max(height(root.left), height(root.right));
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