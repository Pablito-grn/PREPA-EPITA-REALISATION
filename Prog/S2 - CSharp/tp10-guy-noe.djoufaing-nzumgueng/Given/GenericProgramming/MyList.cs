using System;

namespace WWW
{
    public class MyList<T>
    {
        public Node<T> head;
        public Node<T> tail;

        /// <summary>
        /// Sets head and tail to null
        /// </summary>
        public MyList()
        {
            head = null;
            tail = null;
        }

        /// <summary>
        /// Returns the node at the given index
        /// </summary>
        /// <param name="index"> Index of the node to return</param>
        public Node<T> get_node(int index)
        {
            if (index < 0)
                return null;
            
            Node<T> res = head;
            
            for (int i = 1; i < index; i++)
            {
                res = res.next;
                
                if (res == null) // index out of range
                    return null;
            }

            return res;
        }

        /// <summary>
        /// Returns the value at the given index
        /// </summary>
        /// <param name="index"> Index of the value to return</param>
        public T get(int index)
        {
            Node<T> nodeTest = get_node(index);
            
            if (nodeTest == null) 
                throw new ArgumentException();

            return nodeTest.get_value();
        }

        /// <summary>
        /// Adds an element at the end of the list
        /// </summary>
        /// <param name="value"> Element to add</param>
        public void append(T value)
        {
                
            Node<T> valToAppend = new Node<T>(value);

            if (head == null)
            {
                head = valToAppend;
                tail = valToAppend;
            }
            else if (head == tail)
            {
                head.next = valToAppend;
                tail = valToAppend;
                tail.prev = head;
            }
            else
            {
               
            tail.next = valToAppend;
            
            // mise a jour des attributs
            tail.next.next = null;
            tail.next.prev = tail;
            tail = tail.next;
 
            }

        }

        
        /// <summary>
        /// Prints the list on the console.
        /// </summary>
        public void print()
        {
            Node<T> printVal = head;

            if (printVal != null)
            {
                Console.Write(printVal.get_value());
                
                printVal = printVal.next;
                while (printVal != tail.next)
                {
                    Console.Write(" "+ printVal.get_value());
                    printVal = printVal.next;
                }
            }
            
            Console.WriteLine();
        }

        /// <summary>
        /// Adds an element at the beginning of the list
        /// </summary>
        /// <param name="value"> Element to add</param>
        public void prepend(T value)
        {
            Node<T> valToAppend = new Node<T>(value);
            head.prev = valToAppend;
            
            if (head == null)
            {
                head = valToAppend;
                tail = valToAppend;
            }
            else if (head == tail)
            {
                head.prev = valToAppend;
                head.prev.next = head;
                head = valToAppend;
            }
            else
            {
                // mise a jour des attributs
                head.prev = valToAppend;
                head.prev.next = head; 
                head = head.prev;
            }
        }

        /// <summary>
        /// Adds an element in the list at the given index
        /// </summary>
        /// <param name="value"> Element to add</param>
        /// <param name="index"> Index of the element to add</param>
        public void insert(T value, int index)
        {
            Node<T> valToInsert = new Node<T>(value);
            
            if(get_node(index) ==  null)
                throw new ArgumentException();

            Node<T> tmp = get_node(index);
            if (tmp != null)
                 if (tmp == tail)
                    append(value);
                 else if(tmp == head)
                     prepend(value);
                 else
                {               
                    valToInsert.next = tmp; 
                    valToInsert.prev = tmp.prev;
                    tmp.prev = valToInsert;
                    tmp.prev.next = valToInsert;
                }

        }

        /// <summary>
        /// Removes an element at the beginning of the list
        /// </summary>
        public T prepop()
        {
            var val = head.get_value();

            if (head == null)
                throw new Exception();
            
            // mise a jour des attributs
            head.next.prev = null;
            head = head.next;

            return val;
        }

        /// <summary>
        /// Removes an element at the end of the list
        /// </summary>
        public T pop()
        {
            var val = tail.get_value();
            
            if (tail == null)
                throw new Exception();
            
            // mise a jour des attributs
            tail.prev.next = null;
            tail = tail.prev;

            return val;
            
        }

        /// <summary>
        /// Removes an element of the list at the given index
        /// </summary>
        /// <param name="index"> Index of the element to remove</param>
        public T remove_at(int index)
        {
            T val;
            if(get_node(index) ==  null)
                throw new ArgumentException();

            if (get_node(index) == head)
                val = prepop();
            else if (get_node(index) == tail)
                val = pop();
            else
            { 
                val = get_node(index).get_value();
                get_node(index).prev.next = get_node(index).next;
                get_node(index).next.prev = get_node(index).prev;
            }

            return val;
        }
    }
}
