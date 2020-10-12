using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace TheCSharp.DataStructure
{
    public class DataStrcuture
    {
        public void Array()
        {
            var rollNumbers = new int[4] { 1, 2, 3, 4 };

            int rollNumberLength = rollNumbers.Length;

            // array update
            rollNumbers.SetValue(100, 0); // set 100 to 0 index

            // array traversal
            for (int index = 0; index < rollNumbers.Length; index++)
            {
                Debug.Write($"{rollNumbers[index]}");
            }

            // access index item
            int roll = rollNumbers[1];

        }

        public void List()
        {
            // declare and assign
            var rollNumberList = new List<int>(3) { 1, 2, 3 };

            // traversal
            foreach (int roll in rollNumberList)
            {
                Debug.Write($"{roll}");
            }

            // access a particular item
            int rollNumber = rollNumberList[1];

            // added item dynamically
            rollNumberList.Add(4);

            // remove a particular item
            rollNumberList.Remove(1);

            // existence check
            bool exists = rollNumberList.Contains(2);
        }

        public void HashTable()
        {
            // declare and initialize
            var dictionary = new Dictionary<int, string>(3) { { 1, "A" }, { 2, "B" }, { 3, "C" } };

            // accessing first item
            string istItem = dictionary[1];

            // traversal
            foreach (KeyValuePair<int, string> item in dictionary)
            {
                Debug.WriteLine($"Key={item.Key} Value={item.Value}");
            }

            // adding new item
            dictionary.Add(4, "D");

            // remove a particular item
            dictionary.Remove(1);
        }

        public void HashSet()
        {
            var set = new HashSet<int>();

            // adding item. ignore duplicate values.
            set.Add(1);
            set.Add(1);
            set.Add(2);

            // remove a particular item
            set.Remove(1);

            // traversal
            foreach (int item in set)
            {
                Debug.Write($"item");
            }
        }

        public void Stack()
        {
            // declaration
            var stack = new Stack<int>(3);

            // adding
            stack.Push(1);
            stack.Push(2);

            // feching lastly inserted (with removing from stack)
            int item = stack.Pop();

            // fetching lastly inserted item without removing from stack
            int nextItem = stack.Peek();

            int totalItems = stack.Count();
        }

        public void Queue()
        {
            var queue = new Queue<int>(3);

            //adding 
            queue.Enqueue(1);
            queue.Enqueue(2);

            // feching with removing first item from queue
            int item = queue.Dequeue();

            //feching without removing first item from queue
            int item2 = queue.Peek();

            int totalItems = queue.Count();
        }

        public void LinkList()
        {
            // declaring 
            var linkList = new LinkedList<int>();

            // adding item
            linkList.AddLast(1);
            linkList.AddLast(2);
            linkList.AddFirst(3);
            linkList.AddFirst(4);

            // removing item
            linkList.RemoveLast();
            linkList.Remove(1);
            linkList.RemoveFirst();

            // checking item existence
            bool found = linkList.Contains(1);

            // traversing
            foreach (int item in linkList)
            {
                Debug.Write(item);
            }
        }

    }
}
