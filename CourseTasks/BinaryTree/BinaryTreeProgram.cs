using System;
using System.Collections.Generic;

namespace BinaryTree
{
    internal class BinaryTreeProgram
    {
        private static void Main()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(10);
            tree.Add(13);
            tree.Add(7);
            tree.Add(15);
            tree.Add(13);
            tree.Add(5);
            tree.Add(9);
            tree.Add(8);
            tree.Add(4);
            tree.Add(7);
            tree.Add(2);
            tree.Add(12);
            tree.Add(11);

            bool isNode = tree.Contains(2);

            int count = tree.Count;
            tree.DeleteNode(10);

            IEnumerable<int> setOfNodes = tree.GetAroundInWide();

            foreach (int node in setOfNodes)
            {
                Console.Write("{0} ", node);
            }

            Console.WriteLine();

            setOfNodes = tree.GetAroundInDeepWithRecursion();

            foreach (int node in setOfNodes)
            {
                Console.Write("{0} ", node);
            }

            Console.WriteLine();

            setOfNodes = tree.GetAroundInDeepWithoutRecursion();

            foreach (int node in setOfNodes)
            {
                Console.Write("{0} ", node);
            }

            Console.ReadLine();
        }
    }
}
