namespace MyClass;

public class MyClass
{
    public static IPrinter<T> FabricMethod<T>()
    {
        if (typeof(T) == typeof(string))
        {
            return (IPrinter<T>) new StringPrinter();
        }

        if (typeof(T) == typeof(int))
        {
            return (IPrinter<T>)new IntPrinter();
        }

        throw new InvalidOperationException();
    }
}