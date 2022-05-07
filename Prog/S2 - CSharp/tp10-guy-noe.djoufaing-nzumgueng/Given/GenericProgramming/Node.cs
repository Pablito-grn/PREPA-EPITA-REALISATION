using System;

namespace WWW
{
    public class Node<T>
    {
        private T value;
        public Node<T> next;
        public Node<T> prev;

        /// <summary>
        /// Initializes value and set next and prev to null
        /// </summary>
        /// <param name="value"> Value to initialize this.value with</param>
        public Node(T value)
        {
            this.value = value;
            next = null;
            prev = null;
        }

        /// <summary>
        /// Returns the node value
        /// </summary>
        public T get_value()
        {
            return value;
        }
    }
}