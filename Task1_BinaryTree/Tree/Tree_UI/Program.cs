using BinaryTreeSearch;
using System;

namespace Tree_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add("Sergey", "Physics", DateTime.Now, 5);
            tree.Add("Mihail", "Math", DateTime.Now, 3);
            tree.Add("Jony", "Prof", DateTime.Now, 7);
            tree.Add("Alex", "Libr", DateTime.Now, 1);
            tree.Add("Victor", "Physics", DateTime.Now, 2);
            tree.Add("Anna", "Physics", DateTime.Now, 8);
            tree.Add("Maria", "Physics", DateTime.Now, 6);
            tree.Add("Lev", "Physics", DateTime.Now, 9);

            var list = tree.GetNodesPrefix();
            foreach(Node<int> tmp in list)
                Console.WriteLine($"|{tmp.Name}\t{tmp.TestName}\t{tmp.Date.ToShortDateString()} =>\t|{tmp.Result}|");

            Console.ReadLine();
        }
    }
}
