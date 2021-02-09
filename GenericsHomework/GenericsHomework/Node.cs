using System;

namespace GenericsHomework
{
    public class Node<T>
    {
        private T? _Value;
        private Node<T>? _Next;

        public T Value
        {
            get => _Value!;

            set
            {
                _Value = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
        public Node<T> Next
        {
            get => _Next!;

            private set
            {
                value._Next = this;
                _Next = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public Node(T value)
        {
            this.Value = value;
            this.Next = this;
        }

        public void Insert(T value)
        {
            Node<T> node = new Node<T>(value);
            this.Next = node;
        }

        /*
         * All that is necessary for the clearing method is to have the 'Next' property of the current node point to itself.
         *  Reason being is the other nodes in the list may still have a reference to the current node, but the other nodes wil have no other reference
         *  within the program, and therefore the garbage collector will not be able to reference them within the program and will release
         *  them from memory. 
         */
        public void Clear()
        {
            this.Next = this;
        }

        public override string ToString()
        {
            if (Value is null)
            {
                throw new ArgumentNullException(nameof(Value));
            }

            return Value.ToString() ?? "";
        }
    }
}
