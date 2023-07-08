using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public interface ILibrary<T> : IReadOnlyCollection<T>
{
    void Add(T item);
    T Borrow(string title);
    void Return(T item);
    List<T> SearchByTitle(string title);
}

public class Library<T> : ILibrary<T>
{
    private Dictionary<string, T> items;

    public Library()
    {
        items = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
    }

    public int Count => items.Count;

    public void Add(T item)
    {
        // Assuming the item has a property named "Title"
        var titleProperty = item.GetType().GetProperty("Title");
        if (titleProperty != null)
        {
            string title = (string)titleProperty.GetValue(item);
            items[title] = item;
        }
    }

    public T Borrow(string title)
    {
        if (items.ContainsKey(title))
        {
            T item = items[title];
            items.Remove(title);
            return item;
        }

        return default(T);
    }

    public void Return(T item)
    {
        // Assuming the item has a property named "Title"
        var titleProperty = item.GetType().GetProperty("Title");
        if (titleProperty != null)
        {
            string title = (string)titleProperty.GetValue(item);
            items[title] = item;
        }
    }

    public List<T> SearchByTitle(string title)
    {
        return items.Values.Where(item =>
        {
            var itemTitle = item.GetType().GetProperty("Title")?.GetValue(item)?.ToString();
            return itemTitle != null && itemTitle.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0;
        })
        .ToList();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return items.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
