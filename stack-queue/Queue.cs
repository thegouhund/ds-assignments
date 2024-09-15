namespace ConsoleApp1
{
	public class Queue : Stack
	{
		private Node? _last;
		public Node? last { get => _last; set => _last = value; }

		public override void push(char value)
		{
			Node newNode = new(value);
			if (first == null)
			{
				first = last = newNode;
			}
			else
			{
				last!.next = newNode;
				newNode.prev = last;
				last = newNode;
			}
			Console.WriteLine($"Pushed {value} to queue");
		}

		public override void delete(int index)
		{
			Node? node = null;
			Node? current = first;

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

			node.prev.next = node.next;
		}

		public override void swap(int index1, int index2)
		{
			if (index1 == index2) return;
			Console.WriteLine($"Swapping index-{index1} with index-{index2}");

			Node? node1 = null, node2 = null;
			Node current = first;

			int count = 0;
			while (current != null)
			{
				if (count == index1) node1 = current;
				if (count == index2) node2 = current;
				if (node1 != null && node2 != null) break;
				current = current.next;
				count++;
			}

			if (node1 == null || node2 == null) { Console.WriteLine("Index out of bounds"); return; }

			if (node1.prev != null)
			{
				node1.prev.next = node2;
			}
			else
			{
				first = node2;
			}

			if (node2.prev != null)
			{
				node2.prev.next = node1;
			}
			else
			{
				first = node1;
			}

			Node tempNext = node1.next;
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