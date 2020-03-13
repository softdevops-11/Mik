using System;

namespace BinaryTree
{
    internal class BinaryTreeProgram
    {
        private static void Main()
        {
            BinaryTree<int> tree = new BinaryTree<int>(10);
            tree.RootNode = tree.Add(13, tree.RootNode);
            tree.RootNode = tree.Add(7, tree.RootNode);
            tree.RootNode = tree.Add(15, tree.RootNode);
            tree.RootNode = tree.Add(13, tree.RootNode);
            tree.RootNode = tree.Add(5, tree.RootNode);
            tree.RootNode = tree.Add(9, tree.RootNode);
            tree.RootNode = tree.Add(8, tree.RootNode);
            tree.RootNode = tree.Add(4, tree.RootNode);
            tree.RootNode = tree.Add(7, tree.RootNode);
            tree.RootNode = tree.Add(3, tree.RootNode);
            tree.RootNode = tree.Add(12, tree.RootNode);
            tree.RootNode = tree.Add(11, tree.RootNode);

            BinaryTreeNode<int> foundNode = tree.FindNode(8, tree.RootNode);

            int count = tree.GetCountNodes(tree.RootNode);
            tree.DeleteNode(10);

            Console.WriteLine(tree.GetAroundInWide(tree.RootNode));
            Console.WriteLine();

            Console.WriteLine(tree.GetAroundInDeepWithRecursion(tree.RootNode));
            Console.WriteLine();

            Console.WriteLine(tree.GetAroundInDeepWithoutRecursion(tree.RootNode));

            Console.ReadLine();
        }
    }
}
