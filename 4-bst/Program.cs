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

    public void Insert(int key)
    {
        root = InsertKey(root!, key);
    }

    private Node InsertKey(Node root, int key)
    {
        if (root == null)
        {
            root = new Node(key);
            return root;
        }

        if (key < root.Key)
            root.Left = InsertKey(root.Left, key);
        else if (key > root.Key)
            root.Right = InsertKey(root.Right, key);

        return root;
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
            InorderRec(root.Right);
            Console.Write(root.Key + " -> ");
        }
    }

    public void DeleteKey(int key)
    {
        root = DeleteRec(root!, key);
    }

    private Node DeleteRec(Node root, int key)
    {
        if (root == null) return root!;

        if (key < root.Key)
            root.Left = DeleteRec(root.Left, key);
        else if (key > root.Key)
            root.Right = DeleteRec(root.Right, key);
        else
        {
            if (root.Left == null)
                return root.Right;
            else if (root.Right == null)
                return root.Left;

            root.Key = MinValue(root.Right);
            root.Right = DeleteRec(root.Right, root.Key);
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

    public bool Find(int key)
    {
        return FindRec(root!, key);
    }

    private bool FindRec(Node root, int key)
    {
        if (root == null) return false;
        else if (key == root.Key) return true;
        else if (key < root.Key) return FindRec(root.Left, key);
        else return FindRec(root.Right, key);
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

        tree.Insert(8);
        tree.Insert(5);
        tree.Insert(2);
        tree.Insert(9);
        tree.Insert(10);
        tree.Insert(4);
        tree.Insert(3);
        tree.Insert(1);
        tree.DeleteKey(5);

        Console.WriteLine("Tree structure:");
        tree.PrintTree();
    }
}
