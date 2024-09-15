namespace Week1
{
    public class Stack : LinkedList
    {
        public virtual void push(char value)
        {
            Node newNode = new(value);
            newNode.next = First!;
            First = newNode;
            Console.WriteLine($"Pushed {value} to stack");
        }

        public bool hasPop()
        {
            if (First == null)
            {
                return false;
            }
            return true;
        }

        public char? pop()
        {
            if (hasPop())
            {
                First = First!.next!;
                Console.WriteLine("List popped");
                return First.value;
            }
            Console.WriteLine("List is empty");
            return null;
        }

        public virtual void delete(int index)
        {
            Node? node = null;
            Node? prev = null;
            Node? current = First;

            int count = 0;
            while (current != null)
            {
                if (count == index - 1) prev = current;
                if (count == index) node = current;
                current = current!.next;
                count++;

                if (node != null) break;
            }

            if (node == null) { Console.WriteLine("Index out of bounds"); return; }
            prev!.next = node.next;
        }

        public virtual void swap(int index1, int index2)
        {
            if (index1 == index2) return;

            Console.WriteLine($"Swapping index-{index1} with index-{index2}");
            Node? prev1 = null, prev2 = null;
            Node? node1 = null, node2 = null;
            Node? current = First;

            int count = 0;
            while (current != null)
            {
                if (count == index1 - 1) prev1 = current;
                if (count == index1) node1 = current;
                if (count == index2 - 1) prev2 = current;
                if (count == index2) node2 = current;

                if (node1 != null && node2 != null) break;

                current = current.next;
                count++;
            }

            if (node1 == null || node2 == null) { Console.WriteLine("Index out of bounds"); return; }


            if (prev2 == node1)
            {
                Node? tempNode = node2.next;
                node2.next = node1;
                node1.next = tempNode;
                if (prev1 != null) prev1.next = node2;
                else First = node2;
            }
            else if (prev1 == node2)
            {
                Node? tempNode = node1.next;
                node1.next = node2;
                node2.next = tempNode;
                if (prev2 != null) prev2.next = node1;
                else First = node1;
            }
            else
            {
                Node? tempNode = node1.next;

                if (prev1 != null) prev1.next = node2;
                else First = node2;

                if (prev2 != null) prev2.next = node1;
                else First = node1;

                node1.next = node2.next;
                node2.next = tempNode;
            }
        }
    }
}
