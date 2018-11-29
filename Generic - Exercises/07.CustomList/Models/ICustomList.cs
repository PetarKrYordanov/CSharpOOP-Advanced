﻿using System;
using System.Collections.Generic;
using System.Text;

public interface ICustomList<T> : ISorter<T>
{
    void Add(T element);

    T Remove(int index);

    bool Contains(T element);

    void Swap(int index1, int index2);

    int CountGreaterThan(T element);

    T Max();

    T Min();
}

