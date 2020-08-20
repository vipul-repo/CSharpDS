namespace CSharpDS
{
    class Node
    {
        public int value { get; }
        public Node left { get; set; }
        public Node right { get; set; }

        public Node(int value)
        {
            this.value = value;
        }

        public static string GetInOrderTreeString(Node node, string printString = "")
        {
            if (node == null)
                return printString;

            printString = GetInOrderTreeString(node.left, printString);
            printString += $"{node.value}, ";
            printString = GetInOrderTreeString(node.right, printString);

            return printString;
        }
    }

}