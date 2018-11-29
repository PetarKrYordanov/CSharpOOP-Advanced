using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Box<T> : IComparable<Box<T>> 
        where T : IComparable
{
    private List<T> list;

    public Box()
    {
        this.Value = default(T);
        this.list = new List<T>();
    }

    public Box(T value)
    {
        this.Value = value;
    }

    public void Add(T element)
    {
        this.list.Add(element);
    }

    public T Value { get; set; }

    public int CompareTo(Box<T> other)
    {
        return this.Value.CompareTo(other.Value);
    }

    public override string ToString()
    {
        return $"{typeof(T).FullName}: {this.Value}";
    }
}

