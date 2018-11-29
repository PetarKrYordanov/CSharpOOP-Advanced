using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T> : ICustomList<T>, IEnumerable<T> where T : IComparable<T>
{
    public const int Initial_Capcity = 2;

    public int Count { get; private set; }

    private T[] items;

    public CustomList()
    {
        this.items = new T[Initial_Capcity];
    }

    public void Add(T element)
    {
        if (this.Count == this.items.Length)
        {
            this.Resize();
        }

        this.items[this.Count++] = element;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < this.items.Length; i++)
        {
            if (this.items[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;

        for (int i = 0; i < this.items.Length; i++)
        {
            if (this.items[i].CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
        if (this.items.Length == 0)
        {
            throw new NullReferenceException("Collection is empty");
        }

        T maxValue = default(T);

        for (int i = 0; i < this.Count; i++)
        {
            if (this.items[i].CompareTo(maxValue) > 0)
            {
                maxValue = items[i];
            }
        }

        return maxValue;
    }

    public T Min()
    {
        if (this.items.Length == 0)
        {
            throw new NullReferenceException("Collection is empty");
        }

        T maxValue = items[0];

        for (int i = 0; i < this.Count; i++)
        {
            if (this.items[i].CompareTo(maxValue) < 0)
            {
                maxValue = items[i];
            }
        }

        return maxValue;
    }

    public T Remove(int index)
    {
        T[] tempArray = new T[this.Count - 1];

        T element = this.items[index];

        this.Count--;

        for (int i = 0; i < index; i++)
        {
            tempArray[i] = this.items[i];
        }

        for (int i = index + 1; i <= this.Count; i++)
        {
            tempArray[i - 1] = this.items[i];
        }


        this.items = tempArray;

        return element;
    }

    public void Swap(int index1, int index2)
    {
        T firstElement = this.items[index1];
        T secondElement = this.items[index2];

        this.items[index1] = secondElement;
        this.items[index2] = firstElement;
    }

    public void Sort()
    {
        T temp = this.items[0];

        for (int i = 0; i < this.Count; i++)
        {
            for (int j = i + 1; j < this.Count; j++)
            {
                if (this.items[i].CompareTo(this.items[j]) > 0)
                {
                    temp = this.items[i];

                    this.items[i] = this.items[j];

                    this.items[j] = temp;
                }
            }
        }
    }

    private void Resize()
    {
        T[] copy = new T[(this.items.Length + 1) * 2];

        for (int i = 0; i < this.items.Length; i++)
        {
            copy[i] = this.items[i];
        }

        this.items = copy;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.items.Take(this.Count).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.items.Take(this.Count).GetEnumerator();
    }
}

