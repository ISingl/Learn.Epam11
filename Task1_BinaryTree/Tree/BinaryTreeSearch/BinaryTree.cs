using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeSearch
{
    public class Node<T>
        where T : IComparable
    {
        public T Data { get; private set; }
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }

        public Node(T data)
        {
            Data = data;
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (node.CompareTo(Data) == -1)
            {
                if(Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(data);
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
                    Right.Add(data);
                }
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is T item)
            {
                return Data.CompareTo(item);
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

        public void Add(T data)
        {
            if(Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }

            Root.Add(data);
            Count++;
        }
    }
}
