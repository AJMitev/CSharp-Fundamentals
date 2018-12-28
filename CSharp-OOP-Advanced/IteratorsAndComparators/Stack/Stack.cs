namespace Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private Node<T> top;

        public Stack()
        {
            this.top = null;
        }

        private class Node<T>
        {
            public Node(T element)
            {
                this.Element = element;
                this.Prev = null;
            }

            public T Element { get; private set; }

            public Node<T> Prev { get; set; }
        }

        public void Push(T element)
        {
            var current = new Node<T>(element);

            if (this.top == null)
            {
                this.top = current;
            }
            else
            {
                current.Prev = top;
                this.top = current;
            }

        }

        public T Pop()
        {
            if (this.top != null)
            {
                T returnValue = this.top.Element;
                this.top = this.top.Prev;

                return returnValue;
            }

            throw new InvalidOperationException("No elements");
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.top;
            while (current != null)
            {
                yield return current.Element;

                current = current.Prev;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}