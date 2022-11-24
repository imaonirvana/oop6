namespace Program;

class Program
{
    static void Main()
    {
        var list = new MyList<String>(new string[]{"string1", "string2", "string3"});
        list.Add("key1");
        list.Add("key2");
        
        list.Filter(item => !item.Contains("1"));

        var array = list.GetArray();

        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }
}
