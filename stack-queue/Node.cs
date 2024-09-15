namespace ConsoleApp1
{
  public class Node(char value)
  {
    private char _value = value;
    public char value { get => _value; set => _value = value; }
    private Node? _next;
    public Node next { get => _next!; set => _next = value; }
    private Node? _prev;
    public Node prev { get => _prev!; set => _prev = value; }
  }
}