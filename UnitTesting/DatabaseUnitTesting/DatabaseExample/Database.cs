using System;

namespace DatabaseExample
{
   public class Database
    {
        private const int Capacity = 16;

        private int[] data;
        private int index = -1;

        public Database()
        {
            this.data = new int[Capacity];            
        }

        public Database(int[] items) :this()
        {
            if (items.Length>Capacity)
            {
                throw new InvalidOperationException($"Items must be lest than {Capacity}");
            }

            for (int i = 0; i < items.Length; i++)
            {
                this.data[i] = items[i];
            }
            this.index = items.Length - 1;
        }

        public void Add(int item)
        {
            if (index>= Capacity -1)
            {
                throw new InvalidOperationException($"Database is full. You cannot add any elements");
            }

            this.data[++index] = item;
        }

        public void Remove()
        {
            if (index<0)
            {
                throw new InvalidOperationException("Database is empty. You cannot remove elements");
            }

            this.data[index] = default(int);
            index--;
        }

        public int[] Fetch()
        {
            if (index<0)
            {
                return new int[0];
            }

            int[] result = new int[index + 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = this.data[i];
            }
            return result;
        }
    }
}
