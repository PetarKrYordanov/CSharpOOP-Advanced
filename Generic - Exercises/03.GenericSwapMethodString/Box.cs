using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    public Box()
    {
        this.Value = default(T);
    }

    public Box(T value)
    {
        this.Value = value;
    }

    public T Value { get; set; }

    public override string ToString()
    {
        return $"{typeof(T).FullName}: {this.Value}";
    }
}

