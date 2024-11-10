class Node
{
    public int Key;
    public Node Left, Right, Parent;
    public bool isRed;

    public Node(int item)
    {
        Key = item;
        Left = Right = Parent = null!;
        isRed = true;
    }
}

class RedBlackTree
{
    private Node? root;

    public RedBlackTree()
    {
        root = null;
    }

    public void Add(int key)
    {
        Node newNode = new Node(key);
        root = AddRec(root, newNode);
        FixInsert(newNode);
    }

    private Node AddRec(Node? root, Node newNode)
    {
        if (root == null)
            return newNode;

        if (newNode.Key < root.Key)
        {
            root.Left = AddRec(root.Left, newNode);
            root.Left.Parent = root;
        }
        else if (newNode.Key > root.Key)
        {
            root.Right = AddRec(root.Right, newNode);
            root.Right.Parent = root;
        }

        return root;
    }

    private void RotateLeft(Node x)
    {
        Node y = x.Right;
        x.Right = y.Left;

        if (y.Left != null)
            y.Left.Parent = x;

        y.Parent = x.Parent;

        if (x.Parent == null)
            root = y;
        else if (x == x.Parent.Left)
            x.Parent.Left = y;
        else
            x.Parent.Right = y;

        y.Left = x;
        x.Parent = y;
    }

    private void RotateRight(Node x)
    {
        Node y = x.Left;
        x.Left = y.Right;

        if (y.Right != null)
            y.Right.Parent = x;

        y.Parent = x.Parent;

        if (x.Parent == null)
            root = y;
        else if (x == x.Parent.Right)
            x.Parent.Right = y;
        else
            x.Parent.Left = y;

        y.Right = x;
        x.Parent = y;
    }

    private void FixInsert(Node k)
    {
        while (k != root && k.Parent.isRed)
        {
            if (k.Parent == k.Parent.Parent.Left)
            {
                Node uncle = k.Parent.Parent.Right;

                if (uncle != null && uncle.isRed)
                {
                    k.Parent.isRed = false;
                    uncle.isRed = false;
                    k.Parent.Parent.isRed = true;
                    k = k.Parent.Parent;
                }
                else
                {
                    if (k == k.Parent.Right)
                    {
                        k = k.Parent;
                        RotateLeft(k);
                    }
                    k.Parent.isRed = false;
                    k.Parent.Parent.isRed = true;
                    RotateRight(k.Parent.Parent);
                }
            }
            else
            {
                Node uncle = k.Parent.Parent.Left;

                if (uncle != null && uncle.isRed)
                {
                    k.Parent.isRed = false;
                    uncle.isRed = false;
                    k.Parent.Parent.isRed = true;
                    k = k.Parent.Parent;
                }
                else
                {
                    if (k == k.Parent.Left)
                    {
                        k = k.Parent;
                        RotateRight(k);
                    }
                    k.Parent.isRed = false;
                    k.Parent.Parent.isRed = true;
                    RotateLeft(k.Parent.Parent);
                }
            }
        }
        root!.isRed = false;
    }

    public bool isExist(int key)
    {
        return isExistRec(root!, key);
    }

    private bool isExistRec(Node root, int key)
    {
        if (root == null) return false;
        else if (key == root.Key) return true;
        else if (key < root.Key) return isExistRec(root.Left, key);
        else return isExistRec(root.Right, key);
    }

    public void PrintTree()
    {
        PrintTreeRec(root, 0, true);
    }

    private void PrintTreeRec(Node? node, int level, bool isLeft)
    {
        if (node == null) return;

        PrintTreeRec(node.Right, level + 1, false);

        for (int i = 0; i < level; i++)
            Console.Write("    ");

        if (level > 0)
            Console.Write(isLeft ? "└── " : "┌── ");

        Console.ForegroundColor = node.isRed ? ConsoleColor.Red : ConsoleColor.White;
        Console.WriteLine(node.Key);
        Console.ResetColor();

        PrintTreeRec(node.Left, level + 1, true);
    }

    public static void Main(string[] args)
    {
        RedBlackTree tree = new RedBlackTree();
        Random random = new Random();
        int[] numbers = new int[10];

        for (int i = 1; i <= 10; i++)
        {
            numbers[i - 1] = i;
        }

        for (int i = numbers.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            tree.Add(numbers[i]);
        }

        Console.WriteLine("Tree structure:");
        tree.PrintTree();
    }
}
