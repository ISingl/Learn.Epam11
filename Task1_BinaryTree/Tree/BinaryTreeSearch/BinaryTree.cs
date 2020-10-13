﻿using System;
using System.Collections.Generic;

namespace BinaryTreeSearch
{

    public class BinaryTree<T>
        where T : IComparable
    {
        public class Node<T>
        where T : IComparable
        {
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }

            /// <summary>
            /// Test result
            /// </summary>
            public T Result { get; private set; }
            /// <summary>
            /// Student's name
            /// </summary>
            public string Name { get; private set; }
            /// <summary>
            /// The name of the test
            /// </summary>
            public string TestName { get; private set; }
            /// <summary>
            /// Date of passing the test
            /// </summary>
            public DateTime Date { get; private set; }

            public Node(string name, string testName, DateTime date, T result)
            {
                Result = result;
                Name = name;
                TestName = testName;
                Date = date;
            }

            ///// <summary>
            ///// Test completion data
            ///// </summary>
            ///// <param name="name">Student's name</param>
            ///// <param name="testName">The name of the test</param>
            ///// <param name="date">Date of passing the test</param>
            ///// <param name="result">Test result</param>
            //public void Add(string name, string testName, DateTime date, T result)
            //{
            //    var node = new Node<T>(name, testName, date, result);

            //    if (node.CompareTo(Result) == -1)
            //    {
            //        if(Left == null)
            //        {
            //            Left = node;
            //        }
            //        else
            //        {
            //            Left.Add(name, testName, date, result);
            //        }
            //    }
            //    else
            //    {
            //        if(Right == null)
            //        {
            //            Right = node;
            //        }
            //        else
            //        {
            //            Right.Add(name, testName, date, result);
            //        }
            //    }
            //}

            //public int CompareTo(object obj)
            //{
            //    if (obj is T item)
            //    {
            //        return Result.CompareTo(item);
            //    }
            //    else
            //        throw new ArgumentException();
            //}
        }
     
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }
        private IComparer<T> comparer;

        public BinaryTree() : this(Comparer<T>.Default) { }
        public BinaryTree(IComparer<T> comparer)
        {
            if(ReferenceEquals(comparer, null))
            {
                this.comparer = Comparer<T>.Default;
            }

            this.comparer = comparer;
        }
        public BinaryTree(IEnumerable<T> collection)
        {

        }
            /// <summary>
        /// Test completion data
        /// </summary>
        /// <param name="name">Student's name</param>
        /// <param name="testName">The name of the test</param>
        /// <param name="date">Date of passing the test</param>
        /// <param name="result">Test result</param>
        public void Add(string name, string testName, DateTime date, T result)
        {
            var node = new Node<T>(name, testName, date, result);

            if(Root == null)
            {
                Root = node;
            }
            else
            {
                Node<T> current = Root;
                Node<T> parent = null;

                while(current != null)
                {
                    parent = current;
                    if (comparer.Compare(result, parent.Result) < 0)
                        current = current.Left;
                    else
                        current = current.Right;
                }

                if (comparer.Compare(result, parent.Result) < 0)
                    parent.Left = node;
                else
                    parent.Right = node;
            }
            ++Count;
        }


        public List<Node<T>> PreOrder()
        {
            if (Root == null)
            {
                return new List<Node<T>>();
            }

            return PreOrder(Root);
        }

        public List<T> PreOrderResult()
        {
            List<T> list = new List<T>();
            
            foreach (Node<T> node in PreOrder())
                list.Add(node.Result);

            return list;
        }

        private List<Node<T>> PreOrder(Node<T> node)
        {
            List<Node<T>> list = new List<Node<T>>();

            if (node != null)
            {
                list.Add(node);

                if (node.Left != null)
                {
                    list.AddRange(PreOrder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(PreOrder(node.Right));
                }
            }
            return list;
        }
    }
}
