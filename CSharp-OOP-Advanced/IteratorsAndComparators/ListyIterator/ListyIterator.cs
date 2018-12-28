namespace ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection.Metadata.Ecma335;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly T[] _items;
        private int _index;

        public ListyIterator(T[] items)
        {
            this._items = items;
            this._index = 0;
        }

        public bool HasNext()
        {
            return this._index < this._items.Length - 1;
        }

        public bool Move()
        {
            if (this._index < this._items.Length - 1)
            {
                this._index++;

                return true;
            }

            return false;
        }

        public T this[int index]
        {
            get { return this._items[index]; }
            set { this._items[index] = value; }
        }


        public string Print()
        {
            if (this._items.Length == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this._items[this._index].ToString();
        }

        public string PrintAll()
        {
            if (this._items.Length == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return string.Join(" ", this._items);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this._items.Length; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}