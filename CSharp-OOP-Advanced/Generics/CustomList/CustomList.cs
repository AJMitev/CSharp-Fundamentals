namespace CustomList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomList<T> : ICustomList<T>, IEnumerable<T>
        where T : IComparable<T>
    {
        private const int InitialCapacity = 4;

        private T[] array;

        public CustomList()
        {
            this.array = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Add(T element)
        {

            if (this.Count == this.array.Length)
            {
                this.Resize();
            }

            this.array[Count++] = element;
        }



        public T Remove(int index)
        {

            if (this.Count == 0 || index < 0 || index >= this.Count)
            {
                throw new InvalidOperationException();
            }

            T element = this.array[index];

            this.array[index] = default(T);
            this.Count--;

            for (int i = index; i < this.Count; i++)
            {
                this.array[i] = this.array[i + 1];
            }


            return element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int index1, int index2)
        {
            T item = this.array[index1];
            this.array[index1] = this.array[index2];
            this.array[index2] = item;
        }

        public int CountGreaterThan(T element)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            int count = 0;

            for (int i = 0; i < this.Count; i++)
            {
                int comparability = this.array[i].CompareTo(element);

                if (comparability > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T maxElement = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(maxElement) > 0)
                {
                    maxElement = this.array[i];
                }
            }

            return maxElement;
        }

        public T Min()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T minElement = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(minElement) < 0)
                {
                    minElement = this.array[i];
                }
            }

            return minElement;
        }

        private void Resize()
        {
            int newSize = this.array.Length * 2;
            T[] newArray = new T[newSize];

            Array.Copy(this.array, newArray, this.array.Length);


            this.array = newArray;
        }

        public T this[int number]
        {
            get
            {
                if (number >= 0 && number < this.Count)
                {
                    return this.array[number];
                }

                throw new IndexOutOfRangeException();
            }

            set
            {
                if (number >= 0 && number < this.Count)
                {
                    this.array[number] = value;
                }

                throw new IndexOutOfRangeException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        public override string ToString()
        {
            return string.Join("\n", this.array.Take(this.Count));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Sort()
        {
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = 0; j < this.Count; j++)
                {
                    if (this.array[i].CompareTo(this.array[j]) < 0)
                    {
                        T item = this.array[i];
                        this.array[i] = this.array[j];
                        this.array[j] = item;
                    }
                }
            }
        }
    }
}