namespace Program;

// Main concept - have immutable array internally, all manipulations under MyList exemplar just overwrite _items array
// This approach allows to expand functionality as far as developer wants it
public class MyList<T>
{
    private T[] _items;

    public MyList()
    {
        _items = new T[]{};
    }

    public MyList(T[] items)
    {
        _items = items;
    }

    public void Add(T item)
    {
        var newItemsList = new T[_items.Length + 1];

        for (int i = 0; i < _items.Length; i++)
        {
            newItemsList[i] = _items[i];
        }

        newItemsList[_items.Length] = item;

        _items = newItemsList;
    }

    public void Filter(Func<T, bool> predicate)
    {
        var newLength = 0;

        foreach (var item in _items)
        {
            if (predicate(item))
            {
                newLength += 1;
            }   
        }

        var newItemsList = new T[newLength];

        var j = 0;
        for (int i = 0; i < _items.Length; i++)
        {
            if (!predicate(_items[i]))
            {
                continue;
            }
            
            newItemsList[j] = _items[i];
            j += 1;
        }
        
        _items = newItemsList;
    }

    public bool Some(Func<T, bool> predicate)
    {
        var haveSome = false;
        
        foreach (var item in _items)
        {
            if (haveSome)
            {
                break;
            }

            haveSome = predicate(item);
        }

        return haveSome;
    }

    public bool Every(Func<T, bool> predicate)
    {
        var everyHave = true;
        
        foreach (var item in _items)
        {
            if (!everyHave)
            {
                break;
            }

            everyHave = predicate(item);
        }

        return everyHave;
    }
    
    public void Remove(T item)
    {
        this.Filter((itemFromList) => ((object) itemFromList).Equals((object) item));
    }

    public T[] GetArray()
    {
        return _items;
    }
}