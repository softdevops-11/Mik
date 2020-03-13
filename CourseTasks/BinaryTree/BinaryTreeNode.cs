using System;

namespace BinaryTree
{
    internal class BinaryTreeNode<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public BinaryTreeNode<T> Parent { get; set; }
        public T Data { get; set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }
    }
}
