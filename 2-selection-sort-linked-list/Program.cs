namespace Week2
{
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedList q = new();
            int length = 100;
            for (int i = 1; i <= length; i++)
            {
                q.queue(i);
            }

            // Test Cases

            // 1. Fully shuffled array
            q.shuffle();
            Console.WriteLine("Queue telah diacak: ");
            q.printAll();
            q.sort();
            Console.WriteLine("Queue telah disorting: ");
            q.printAll();

            // 2. Reversed array
            q.reverse();
            Console.WriteLine("Queue telah direverse: ");
            q.printAll();
            q.sort();
            Console.WriteLine("Queue telah disorting: ");
            q.printAll();

            // 3. Paritally shuffled array
            q.partialShuffle(5);
            Console.WriteLine("Queue telah diacak sebagian: ");
            q.printAll();
            q.sort();
            Console.WriteLine("Queue telah disorting: ");
            q.printAll();
        }
    }
}
