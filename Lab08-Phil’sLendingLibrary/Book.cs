using System;


public class Book : ICloneable
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public object Clone()
    {
        return new Book(Title, Author);
    }

    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}";
    }
}
