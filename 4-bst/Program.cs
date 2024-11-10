class Node
{
    public int Key;
    public Node Left, Right;

    public Node(int item)
    {
        Key = item;
        Left = Right = null!;
    }
}

class BinarySearchTree
{
    Node? root;

    public BinarySearchTree()
    {
        root = null;
    }

    public bool Add(int key)
    {
        if (root == null)
        {
            root = new Node(key);
            return true;
        }
        return InsertKey(root, key);
    }

    private bool InsertKey(Node root, int key)
    {
        if (key == root.Key) return false;

        if (key < root.Key)
        {
            if (root.Left == null)
            {
                root.Left = new Node(key);
                return true;
            }
            return InsertKey(root.Left, key);
        }
        else
        {
            if (root.Right == null)
            {
                root.Right = new Node(key);
                return true;
            }
            return InsertKey(root.Right, key);
        }
    }

    public void Preorder()
    {
        PreorderRec(root!);
    }

    private void PreorderRec(Node root)
    {
        if (root != null)
        {
            Console.Write(root.Key + " -> ");
            PreorderRec(root.Left);
            PreorderRec(root.Right);
        }
    }

    public void Inorder()
    {
        InorderRec(root!);
    }

    private void InorderRec(Node root)
    {
        if (root != null)
        {
            InorderRec(root.Left);
            Console.Write(root.Key + " -> ");
            InorderRec(root.Right);
        }
    }

    public void Postorder()
    {
        PostorderRec(root!);
    }

    private void PostorderRec(Node root)
    {
        if (root != null)
        {
            PostorderRec(root.Left);
            PostorderRec(root.Right);
            Console.Write(root.Key + " -> ");
        }
    }

    public Boolean Remove(int key)
    {
        if (!isExist(key)) return false;
        root = RemoveRec(root!, key);
        return true;
    }

    private Node RemoveRec(Node root, int key)
    {
        if (root == null) return root!;

        if (key < root.Key)
            root.Left = RemoveRec(root.Left, key);
        else if (key > root.Key)
            root.Right = RemoveRec(root.Right, key);
        else
        {
            if (root.Left == null)
                return root.Right;
            else if (root.Right == null)
                return root.Left;

            root.Key = MinValue(root.Right);
            root.Right = RemoveRec(root.Right, root.Key);
        }

        return root;
    }

    private int MinValue(Node root)
    {
        int minv = root.Key;
        while (root.Left != null)
        {
            minv = root.Left.Key;
            root = root.Left;
        }
        return minv;
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
        {
            Console.Write(isLeft ? "└── " : "┌── ");
        }
        Console.WriteLine(node.Key);

        PrintTreeRec(node.Left, level + 1, true);
    }

    public static void Main(string[] args)
    {
        BinarySearchTree tree = new BinarySearchTree();
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

        Console.WriteLine("Pre-order traversal: ");
        tree.Preorder();
        Console.WriteLine();

        Console.WriteLine("In-order traversal: ");
        tree.Inorder();
        Console.WriteLine();

        Console.WriteLine("Post-order traversal: ");
        tree.Postorder();
        Console.WriteLine();

        Console.WriteLine();

        Console.WriteLine("Tree structure:");
        tree.PrintTree();
    }
}
