namespace Week2
{
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedList q = new();
            int length = 1000;
            for (int i = 1; i <= length; i++)
            {
                q.enqueue(i);
            }

            // Test Cases

            // 1.Fully shuffled array
            q.shuffle();
            Console.WriteLine("Queue telah diacak: ");
            q.printAll();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            q.sort();
            watch.Stop();
            Console.WriteLine("Queue telah disorting: ");
            q.printAll();
            Console.WriteLine("Waktu sort: " + watch.Elapsed.TotalMilliseconds + "ms");

            Console.WriteLine();

            // 2.Reversed array
            q.reverse();
            Console.WriteLine("Queue telah direverse: ");
            q.printAll();
            watch = System.Diagnostics.Stopwatch.StartNew();
            q.sort();
            watch.Stop();
            Console.WriteLine("Queue telah disorting: ");
            q.printAll();
            Console.WriteLine("Waktu sort:" + watch.Elapsed.TotalMilliseconds + "ms");

            Console.WriteLine();

            // 3. Partially shuffled array
            q.partialShuffle(50);
            Console.WriteLine("Queue telah diacak sebagian: ");
            q.printAll();
            watch = System.Diagnostics.Stopwatch.StartNew();
            q.sort();
            watch.Stop();
            Console.WriteLine("Queue telah disorting: ");
            q.printAll();
            Console.WriteLine("Waktu sort: " + watch.Elapsed.TotalMilliseconds + "ms");
        }
    }
}
