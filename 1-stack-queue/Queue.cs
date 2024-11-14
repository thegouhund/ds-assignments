namespace Week1
{
    public class Queue : LinkedList
    {
        public void enqueue(char value)
        {
            Node newNode = new(value);
            if (First == null)
            {
                First = Last = newNode;
            }
            else
            {
                Last!.next = newNode;
                newNode.prev = Last;
                Last = newNode;
            }
            Console.WriteLine($"Pushed {value} to queue");
        }

        public bool hasDequeue()
        {
            if (First == null)
            {
                return false;
            }
            return true;
        }

        public char? dequeue()
        {
            if (hasDequeue())
            {
                First = First!.next!;
                Console.WriteLine("Queue popped");
                return First.value;
            }
            Console.WriteLine("Queue is empty");
            return null;
        }

        public void delete(int index)
        {
            Node? node = null;
            Node? current = First;

            int count = 0;
            while (current != null)
            {
                if (count == index) node = current;
                current = current!.next;
                count++;

                if (node != null) break;
            }

            if (node == null)
            {
                Console.WriteLine("Index out of bounds");
                return;
            }

            node.prev!.next = node.next;
        }

        public void swap(int index1, int index2)
        {
            if (index1 == index2) return;
            Console.WriteLine($"Swapping index-{index1} with index-{index2}");

            Node? node1 = null, node2 = null;
            Node current = First!;

            int count = 0;
            while (current != null)
            {
                if (count == index1) node1 = current;
                if (count == index2) node2 = current;
                if (node1 != null && node2 != null) break;
                current = current.next!;
                count++;
            }

            if (node1 == null || node2 == null) { Console.WriteLine("Index out of bounds"); return; }

            if (node1.prev != null)
            {
                node1.prev.next = node2;
            }
            else
            {
                First = node2;
            }

            if (node2.prev != null)
            {
                node2.prev.next = node1;
            }
            else
            {
                First = node1;
            }

            Node tempNext = node1.next!;
            node1.next = node2.next;
            node2.next = tempNext;

            Node tempPrev = node1.prev!;
            node1.prev = node2.prev!;
            node2.prev = tempPrev;

            if (node1.next != null)
            {
                node1.next.prev = node1;
            }

            if (node2.next != null)
            {
                node2.next.prev = node2;
            }
        }
    }
}
