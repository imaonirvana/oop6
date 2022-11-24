namespace MyClass;

public class StringPrinter: IPrinter<string>
{
    public void Print(string value)
    {
        Console.WriteLine("Some special string implementation");
        
        Console.WriteLine(value);
    }
}