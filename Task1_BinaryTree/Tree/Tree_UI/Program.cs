using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTreeSearch;

namespace Tree_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(2);
            tree.Add(8);
            tree.Add(6);
            tree.Add(9);

        }
    }
}
