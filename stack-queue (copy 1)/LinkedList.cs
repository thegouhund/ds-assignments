namespace Week1
{
    public class LinkedList
    {
        public Node? First { get; set; }
        public Node? Last { get; set; }

        public void printAll()
        {
            Node current = First!;
            while (current != null)
            {
                Console.Write(current.value + " ");
                current = current!.next!;
            }
            Console.WriteLine();
        }
    }
}
