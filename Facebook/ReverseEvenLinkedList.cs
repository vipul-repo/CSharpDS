using System;
using System.Collections.Generic;

class ReverseEvenLinkedList
{
    public static void Main1()
    {
        Node root = null;

        root = new Node(1);
        root.next = new Node(2);
        root.next.next = new Node(8);
        root.next.next.next = new Node(9);
        root.next.next.next.next = new Node(12);
        root.next.next.next.next.next = new Node(16);

        printLinkedList(root);
        root = reverseLinkedList(root);
        printLinkedList(root);

        Console.WriteLine("-------------------");

        root = new Node(1);
        root.next = new Node(3);
        root.next.next = new Node(5);
        root.next.next.next = new Node(7);
        root.next.next.next.next = new Node(9);
        root.next.next.next.next.next = new Node(11);

        printLinkedList(root);
        root = reverseLinkedList(root);
        printLinkedList(root);

        Console.WriteLine("-------------------");

        root = new Node(2);
        root.next = new Node(4);
        root.next.next = new Node(6);
        root.next.next.next = new Node(7);
        root.next.next.next.next = new Node(12);
        root.next.next.next.next.next = new Node(14);
        root.next.next.next.next.next.next = new Node(16);

        printLinkedList(root);
        root = reverseLinkedList(root);
        printLinkedList(root);

        Console.WriteLine("-------------------");

        root = new Node(2);
        root.next = new Node(4);
        root.next.next = new Node(6);
        root.next.next.next = new Node(12);
        root.next.next.next.next = new Node(14);

        printLinkedList(root);
        root = reverseLinkedList(root);
        printLinkedList(root);
    }

    static Node reverseLinkedList(Node root)
    {
        Node prev = null, current = root;

        while (current != null)
        {
            if (current.value % 2 == 0)
            {
                var rev = reverseEvenLinkedList(current);

                if (prev == null)
                    root = rev.start;
                else
                    prev.next = rev.start;

                current = rev.end;
            }

            prev = current;
            current = current.next;
        }

        return root;
    }

    static (Node start, Node end) reverseEvenLinkedList(Node root)
    {
        Node prev = null, current = root, next = null;

        while (current != null && current.value % 2 == 0)
        {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        root.next = current;
        return (prev, root);
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