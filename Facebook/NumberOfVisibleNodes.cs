using System;
using System.Collections.Generic;

class Node
{
    public int value { get; set; }
    public Node left { get; set; }
    public Node right { get; set; }

    public Node(int value)
    {
        this.value = value;
        this.left = this.right = null;
    }
}

class NumberOfVisibleNodes
{
    public static void Main1(string[] args)
    {
        var root = new Node(1);

        root.left = new Node(3);
        root.right = new Node(10);

        root.left.left = new Node(1);
        root.left.right = new Node(6);

        root.right.right = new Node(14);

        root.left.right.left = new Node(4);
        root.left.right.right = new Node(7);

        root.right.right.left = new Node(13);

        Console.WriteLine(visibleNodes(root));
    }

    static int visibleNodes(Node root)
    {
        if (root == null)
            return 0;

        return 1 + Math.Max(visibleNodes(root.left), visibleNodes(root.right));
    }
}