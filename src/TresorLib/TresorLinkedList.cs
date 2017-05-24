using System;

namespace TresorLib
{
    public class TresorLinkedList<T>
    {
        private TresorLinkedListNode<T> First { get; set; }
        private TresorLinkedListNode<T> Last { get; set; }
        public int Count { get; private set; }

        public T this[int index, bool remove = false]
        {
            get
            {
                if(First == null)
                {
                    throw new IndexOutOfRangeException();
                }

                var node = First;
                TresorLinkedListNode<T> prevNode = null;

                for (int i = 0; i < index; i++)
                {
                    prevNode = node;
                    node = node.Next;

                    if(node == null)
                    {
                        throw new IndexOutOfRangeException();
                    }
                }

                if(remove)
                {
                    if (index == 0)
                    {
                        // removing the first node
                        First = node.Next;
                    }
                    else
                    {
                        prevNode.Next = node.Next;
                    }
                    Count--;
                }

                return node.Value;
            }
        }

        public void Add(T item)
        {
            var newNode = new TresorLinkedListNode<T>(item);

            if (Last == null)
            {
                First = Last = newNode;
            }
            else
            {
                var currentLast = Last;
                currentLast.Next = newNode;
                Last = newNode;
            }
            Count++;
        }
    }

    public class TresorLinkedListNode<T>
    {
        public TresorLinkedListNode<T> Next { get; set; }
        public T Value { get; set; }

        public TresorLinkedListNode(T value)
        {
            Value = value;
            Next = null;
        }
    }
}
