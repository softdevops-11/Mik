using System.Collections.Generic;

namespace BinaryTree
{
    internal class BinaryTree<T>
    {
        private BinaryTreeNode<T> RootNode { get; set; }

        public int countNodes { get; private set; }

        private Comparer<T> Comparer { get; set; }

        public BinaryTree()
        {
            RootNode = null;
        }

        public BinaryTree(T data)
        {
            RootNode = new BinaryTreeNode<T>(data);
            Comparer = Comparer<T>.Default;
            countNodes++;
        }

        public BinaryTree(T data, Comparer<T> comparer)
        {
            RootNode = new BinaryTreeNode<T>(data);
            Comparer = comparer;
            countNodes++;
        }

        public void Add(T data)
        {

            if (RootNode == null)
            {
                RootNode = new BinaryTreeNode<T>(data);
            }

            BinaryTreeNode<T> node = RootNode;

            while (node != null)
            {
                if (Comparer.Compare(data, node.Data) < 0)
                {
                    if (node.Left != null)
                    {
                        node = node.Left;
                    }
                    else
                    {
                        node.Left = new BinaryTreeNode<T>(data);
                        countNodes++;
                        return;
                    }
                }
                else
                {
                    if (node.Right != null)
                    {
                        node = node.Right;
                    }
                    else
                    {
                        node.Right = new BinaryTreeNode<T>(data);
                        countNodes++;
                        return;
                    }
                }
            }

        }

        public bool FindNode(T data)
        {
            if (RootNode != null)
            {
                BinaryTreeNode<T> node = RootNode;

                while (node != null)
                {
                    if (Comparer.Compare(data, node.Data) == 0)
                    {
                        return true;
                    }

                    if (Comparer.Compare(data, node.Data) < 0)
                    {
                        node = node.Left;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
            }

            return false;
        }

        public void DeleteNode(T data)
        {
            if (RootNode != null)
            {
                BinaryTreeNode<T> node = RootNode;
                BinaryTreeNode<T> deleteNode = null;
                BinaryTreeNode<T> parentNode = null;

                while (node != null)
                {
                    if (Comparer.Compare(data, node.Data) == 0)
                    {
                        deleteNode = node;
                        break;
                    }

                    if (Comparer.Compare(data, node.Data) < 0)
                    {
                        if (Comparer.Compare(data, node.Left.Data) == 0)
                        {
                            parentNode = node;
                        }

                        node = node.Left;
                    }
                    else
                    {
                        if (Comparer.Compare(data, node.Right.Data) == 0)
                        {
                            parentNode = node;
                        }

                        node = node.Right;
                    }
                }

                if (deleteNode == null)
                {
                    return;
                }

                if (parentNode == null && deleteNode.Left == null && deleteNode.Right == null)
                {
                    RootNode = null;
                    countNodes--;
                    return;
                }

                if (deleteNode.Left == null && deleteNode.Right == null)
                {
                    if (parentNode.Left != null && Comparer.Compare(parentNode.Left.Data, deleteNode.Data) == 0)
                    {
                        parentNode.Left = null;
                        countNodes--;
                    }
                    else
                    {
                        parentNode.Right = null;
                        countNodes--;
                    }
                }
                else if (deleteNode.Left != null && deleteNode.Right == null)
                {
                    if (parentNode == null)
                    {
                        RootNode = deleteNode.Left;
                        countNodes--;
                        return;
                    }

                    if (parentNode.Left != null && Comparer.Compare(parentNode.Left.Data, deleteNode.Data) == 0)
                    {
                        parentNode.Left = deleteNode.Left;
                        countNodes--;
                    }
                    else
                    {
                        parentNode.Right = deleteNode.Left;
                        countNodes--;
                    }
                }
                else if (deleteNode.Right != null && deleteNode.Left == null)
                {
                    if (parentNode == null)
                    {
                        RootNode = deleteNode.Right;
                        countNodes--;
                        return;
                    }

                    if (parentNode.Left != null && Comparer.Compare(parentNode.Left.Data, deleteNode.Data) == 0)
                    {
                        parentNode.Left = deleteNode.Right;
                        countNodes--;
                    }
                    else
                    {
                        parentNode.Right = deleteNode.Right;
                        countNodes--;
                    }
                }
                else
                {
                    BinaryTreeNode<T> minimumNode = deleteNode.Right;
                    BinaryTreeNode<T> parentMinimumNode = minimumNode;

                    while (minimumNode.Left != null)
                    {
                        if (minimumNode.Left.Left == null)
                        {
                            parentMinimumNode = minimumNode;
                        }

                        minimumNode = minimumNode.Left;
                    }

                    deleteNode.Data = minimumNode.Data;
                    countNodes--;

                    if (minimumNode.Right != null)
                    {
                        parentMinimumNode.Left = minimumNode.Right;
                    }
                    else
                    {
                        parentMinimumNode.Left = null;
                    }
                }
            }
        }

        public IEnumerable<T> GetAroundInWide()
        {
            BinaryTreeNode<T> node = RootNode;

            if (node == null)
            {
                yield break;
            }

            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(node);

            while (queue.Count != 0)
            {
                node = queue.Dequeue();
                yield return node.Data;

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }

        public IEnumerable<T> GetAroundInDeepWithRecursion()
        {
            return GetAroundInDeepWithRecursion(RootNode);
        }

        public IEnumerable<T> GetAroundInDeepWithRecursion(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            yield return node.Data;

            if (node.Left != null)
            {
                foreach (var nodes in GetAroundInDeepWithRecursion(node.Left))
                {
                    yield return nodes;
                }
            }

            if (node.Right != null)
            {
                foreach (var nodes in GetAroundInDeepWithRecursion(node.Right))
                {
                    yield return nodes;
                }
            }
        }

        public IEnumerable<T> GetAroundInDeepWithoutRecursion()
        {
            BinaryTreeNode<T> node = RootNode;

            if (node == null)
            {
                yield break;
            }

            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(node);

            while (stack.Count != 0)
            {
                node = stack.Pop();
                yield return node.Data;

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }
    }
}
