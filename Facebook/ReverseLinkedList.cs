using System;
using System.Collections.Generic;

class ReverseLinkedList
{

    public static void Main1()
    {
        Node root = null;

        root = new Node(1);
        root.next = new Node(2);
        root.next.next = new Node(3);
        root.next.next.next = new Node(4);
        root.next.next.next.next = new Node(5);

        printLinkedList(root);
        root = reverseLinkedList(root);
        printLinkedList(root);
        printLinkedList(root);
    }

    static Node reverseLinkedList(Node root)
    {
        Node prev = null, current = root, next = null;

        while (current != null)
        {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }

    static void printLinkedList(Node root)
    {
        var values = new List<int>();

        while (root != null)
        {
            values.Add(root.value);
            root = root.next;
        }

        Console.WriteLine(string.Join(", ", values));
    }

    class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
            this.next = null;
        }
    }
}