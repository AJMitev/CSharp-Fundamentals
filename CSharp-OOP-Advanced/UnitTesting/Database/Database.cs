namespace Database
{
    using System;
    using System.Linq;

    public class Database
    {
        private const int Capacity = 16;

        private int[] data;
        private int index;

        public Database()
        {
            this.data = new int[Capacity];
            this.index = -1;
        }

        public Database(int[] values) : this()
        {
            if (values.Length > 16)
            {
                throw new InvalidOperationException();
            }

            for (int i = 0; i < values.Length; i++)
            {
                this.data[i] = values[i];
            }

            this.index = values.Length - 1;
        }


        public void Add(int value)
        {
            if (this.index < Capacity - 1)
            {
                this.data[++index] = value;
            }
            else
            {
                throw new InvalidOperationException("Database is full!");
            }
        }

        public void Remove()
        {
            if (this.index == -1)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.data[index] = 0;
            this.index--;
        }

        public int[] Fetch()
        {
            return this.data.Take(index+1).ToArray();
        }
    }
}