using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeSearch
{
    public class BinaryTree
    {
        public class Node<T>
        {
            public T Data { get; private set; }
            public Node<T> Left{ get; private set; }
            public Node<T> Right { get; private set; }

            public Node(T data)
            {
                Data = data;
            }

        }
    }
}
