namespace GenericBox
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
        where T : IComparable<T>
    {
        public Box(List<T> items)
        {
            this.Items = items;
        }

        public List<T> Items { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in Items)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }

        public void Swap(int index1, int index2)
        {
            T item = this.Items[index1];
            this.Items[index1] = this.Items[index2];
            this.Items[index2] = item;
        }

        public int ItemsGreaterThan(T inputItem)
        {
            int count = 0;

            foreach (T item in this.Items)
            {
                int comparability = item.CompareTo(inputItem);

                if (comparability == 1)
                {
                    count++;
                }
            }

            return count;
        }
    }
}