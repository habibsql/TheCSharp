using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TheCSharp.DataStructure
{
    public class DataStructureTest
    {
        private readonly DataStrcuture dataStructure = new DataStrcuture();

        [Fact]
        public void ArrayTest()
        {
            dataStructure.Array();
        }

        [Fact]
        public void ListTest()
        {
            dataStructure.List();
        }

        [Fact]
        public void HashTableTest()
        {
            dataStructure.HashTable();
        }

        [Fact]
        public void HashSetTest()
        {
            dataStructure.HashSet();
        }

        [Fact]
        public void StackTest()
        {
            dataStructure.Stack();
        }

        [Fact]
        public void QueueTest()
        {
            dataStructure.Queue();
        }

        [Fact]
        public void LinkListTest()
        {
            dataStructure.LinkList();
        }

    }
}
