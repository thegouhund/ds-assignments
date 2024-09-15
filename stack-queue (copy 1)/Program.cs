using Week1;

public class Program
{
    public static void Main(string[] args)
    {
        Stack stack = new Stack();
        stack.push('A');
        stack.push('B');
        stack.push('C');
        stack.push('D');
        stack.push('E');
        stack.printAll();
        stack.swap(2, 1);
        stack.printAll();
    }
}
