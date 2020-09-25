using System;
using System.Collections.Generic;

namespace BinaryTreeSearch
{
    public class Node<T>
        where T : IComparable
    {        
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }

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

            if (node.CompareTo(Result) == -1)
            {
                if(Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(name, testName, date, result);
                }
            }
            else
            {
                if(Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(name, testName, date, result);
                }
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is T item)
            {
                return Result.CompareTo(item);
            }
            else
                throw new ArgumentException();
        }
    }

    public class BinaryTree<T>
        where T : IComparable
    {       
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }

        /// <summary>
        /// Test completion data
        /// </summary>
        /// <param name="name">Student's name</param>
        /// <param name="testName">The name of the test</param>
        /// <param name="date">Date of passing the test</param>
        /// <param name="result">Test result</param>
        public void Add(string name, string testName, DateTime date, T result)
        {
            if(Root == null)
            {
                Root = new Node<T>(name, testName, date, result);
                Count = 1;
                return;
            }

            Root.Add(name, testName, date, result);
            Count++;
        }

        public List<Node<T>> GetNodesPrefix()
        {
            if (Root == null)
            {
                return new List<Node<T>>();
            }

            return GetNodesPrefix(Root);
        }
        private List<Node<T>> GetNodesPrefix(Node<T> node)
        {
            List<Node<T>> list = new List<Node<T>>();

            if (node != null)
            {
                list.Add(node);

                if (node.Left != null)
                {
                    list.AddRange(GetNodesPrefix(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(GetNodesPrefix(node.Right));
                }
            }
            return list;
        }

        #region PreOrder
        /*
        public List<T> GetPrefix()
        {
            if(Root == null)
            {
                return new List<T>();
            }

            return GetPrefix(Root);
        }
        private List<T> GetPrefix(Node<T> node)
        {
            List<T> list = new List<T>();
            
            if(node != null)
            {
                list.Add(node.Result);

                if(node.Left != null)
                {
                    list.AddRange(GetPrefix(node.Left));
                }

                if(node.Right != null)
                {
                    list.AddRange(GetPrefix(node.Right));
                }
            }
            return list;
        }*/
        #endregion
    }
}
