using System;
using System.Collections.Generic;

public interface IBag<T> : IEnumerable<T>
{
    void Pack(T item);
    T Unpack(int index);
}

public class Backpack<T> : IBag<T>, ICloneable
{
    private List<T> items;

    public Backpack()
    {
        items = new List<T>();
    }

    public int Count => items.Count;

    public void Pack(T item)
    {
        if (item != null)
        {
            items.Add(item);
        }
    }

    public T Unpack(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            T item = items[index];
            items.RemoveAt(index);
            return item;
        }

        return default(T);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public object Clone()
    {
        Backpack<T> backpack = new Backpack<T>();
        foreach (var item in items)
        {
            backpack.Pack(item);
        }
        return backpack;
    }
}
