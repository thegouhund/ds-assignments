namespace Week2
{
    public class LinkedList
    {
        Node? first;
        Node? last;

        public void queue(int value)
        {
            Node newNode = new(value);
            if (first == null)
            {
                first = last = newNode;
            }
            else
            {
                last!.Next = newNode;
                newNode.Prev = last;
                last = newNode;
            }
            Console.WriteLine($"Pushed {value} to queue");
        }

        public bool hasEnqueue()
        {
            if (first == null)
            {
                return false;
            }
            return true;
        }

        public int? enqueue()
        {
            if (hasEnqueue())
            {
                first = first!.Next!;
                Console.WriteLine("List popped");
                return first.Value;
            }
            Console.WriteLine("List is empty");
            return null;
        }

        public void printAll()
        {
            Node current = first!;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current!.Next!;
            }
            Console.WriteLine();
        }

        private void swapNodes(Node node1, Node node2)
        {
            if (node1.Prev != null)
            {
                node1.Prev.Next = node2;
            }
            else
            {
                this.first = node2;
            }

            if (node2.Prev != null)
            {
                node2.Prev.Next = node1;
            }
            else
            {
                this.first = node1;
            }

            Node tempNext = node1.Next!;
            node1.Next = node2.Next;
            node2.Next = tempNext;

            Node tempPrev = node1.Prev!;
            node1.Prev = node2.Prev!;
            node2.Prev = tempPrev;

            if (node1.Next != null)
            {
                node1.Next.Prev = node1;
            }

            if (node2.Next != null)
            {
                node2.Next.Prev = node2;
            }
        }

        public void sort()
        {
            for (Node i = first!; i != null; i = i.Next!)
            {
                Node min = i;

                for (Node j = i.Next!; j != null; j = j.Next!)
                {
                    if (min.Value > j.Value) min = j;
                }

                if (min != i)
                {
                    // nodes wont swap properly ¯\_(ツ)_/¯
                    int temp = i.Value;
                    i.Value = min.Value;
                    min.Value = temp;
                }
            }
        }
    }
}
