namespace BinaryTree
{
    internal class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public T Data { get; set; }

        public BinaryTreeNode()
        {
        }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }
    }
}