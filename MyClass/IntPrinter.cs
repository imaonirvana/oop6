namespace MyClass;

public class IntPrinter: IPrinter<int>
{
    public void Print(int value)
    {
        Console.WriteLine("Some special int implementation");
        
        Console.WriteLine(value);
    }
}