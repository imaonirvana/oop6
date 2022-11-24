namespace MyDictionary;

public class MyDictionary<Key, Value>
{
    private List<Key> _keys;
    private List<Value> _values;

    public Value? this[Key key]
    {
        get
        {
            var index = GetKeyIndex(key);

            return _values[index];
        }

        set
        {
            if (value == null)
            {
                Remove(key);
                
                return;
            }
            
            var index = GetKeyIndex(key);

            if (index == -1)
            {
                Add(key, value);
                
                return;
            }

            _values[index] = value;
        }
    }

    public int Count
    {
        get
        {
            return _keys.Count;
        }
    }

    public MyDictionary()
    {
        _keys = new List<Key>();
        _values = new List<Value>();
    }

    private int Add(Key key, Value value)
    {
        _keys.Add(key);
        _values.Add(value);

        return _keys.Count - 1;
    }

    private void Remove(Key key)
    {
        if (_keys.Contains(key))
        {
            throw new IndexOutOfRangeException();
        }
        
        var index = GetKeyIndex(key);
        
        _keys.RemoveAt(index);
        _values.RemoveAt(index);
    }
    private int GetKeyIndex(Key key)
    {
        var index = _keys.FindIndex((_key) => ((object) _key).Equals((object) key));

        return index;
    }
}