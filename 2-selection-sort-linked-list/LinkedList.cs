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

        private int getLength()
        {
            int count = 0;
            Node? current = first;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public void shuffle()
        {
            Random rand = new();
            int n = getLength();
            while (n > 1)
            {
                int k = rand.Next(n--);
                Node kNode = getNodeAtIndex(k)!;
                Node nNode = getNodeAtIndex(n)!;
                swapNodes(nNode, kNode);
            }
        }

        public void partialShuffle(int swapAmount)
        {
            Random rng = new Random();
            int length = getLength();

            for (int i = 0; i < swapAmount; i++)
            {
                int j = rng.Next(length);
                int k = rng.Next(length);

                Node jNode = getNodeAtIndex(j)!;
                Node kNode = getNodeAtIndex(k)!;
                swapNodes(jNode, kNode);
            }
        }

        public void reverse()
        {
            if (first == null) return;

            Node? i = first;
            while (i != null)
            {
                Node min = i;
                Node? j = i.Next;

                while (j != null)
                {
                    if (min.Value < j.Value) min = j;
                    j = j.Next;
                }

                if (i.Value != min.Value)
                {
                    swapNodes(i, min);
                    i = min.Next;
                }
                else
                {
                    i = i.Next;
                }
            }
        }

        private Node? getNodeAtIndex(int index)
        {
            Node? current = first;
            int counter = 0;

            while (counter != index)
            {
                current = current!.Next;
                counter++;
            }

            return current;
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
            if (first == null) return;

            Node? i = first;
            while (i != null)
            {
                Node min = i;
                Node? j = i.Next;

                while (j != null)
                {
                    if (min.Value > j.Value) min = j;
                    j = j.Next;
                }

                if (i.Value != min.Value)
                {
                    printAll();
                    Console.WriteLine($"Swapping {i.Value} and {min.Value}");
                    swapNodes(i, min);

                    // Move i to the Next node after min (cause min is at i's last position)
                    i = min.Next;
                }
                else
                {
                    i = i.Next;
                }
            }
        }
    }
}
