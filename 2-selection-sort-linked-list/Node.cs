namespace Week2
{
    public class Node(int value)
    {
        public int Value { get; set; } = value;
        public Node? Next { get; set; }
        public Node? Prev { get; set; }
    }
}
