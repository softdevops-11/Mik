﻿using System.Collections.Generic;

namespace BinaryTree
{
    internal class BinaryTree<T>
    {
        private readonly Comparer<T> comparer;

        private BinaryTreeNode<T> rootNode;

        public int Count { get; private set; }

        public BinaryTree()
        {
            comparer = Comparer<T>.Default;
        }

        public BinaryTree(Comparer<T> comparer)
        {
            if (comparer != null)
            {
                this.comparer = comparer;
            }
            else
            {
                this.comparer = Comparer<T>.Default;
            }
        }

        public void Add(T data)
        {
            if (rootNode == null)
            {
                rootNode = new BinaryTreeNode<T>(data);
                Count++;
                return;
            }

            BinaryTreeNode<T> node = rootNode;

            while (node != null)
            {
                if (comparer.Compare(data, node.Data) < 0)
                {
                    if (node.Left != null)
                    {
                        node = node.Left;
                    }
                    else
                    {
                        node.Left = new BinaryTreeNode<T>(data);
                        Count++;
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
                        Count++;
                        return;
                    }
                }
            }
        }

        private BinaryTreeNode<T>[] FindNodeByData(T data)
        {
            BinaryTreeNode<T> foundNode = rootNode;
            BinaryTreeNode<T> parentNode = null;

            while (foundNode != null)
            {
                int comparisonResult = comparer.Compare(data, foundNode.Data);

                if (comparisonResult == 0)
                {
                    break;
                }

                if (comparisonResult < 0)
                {
                    if (foundNode.Left != null && comparer.Compare(data, foundNode.Left.Data) == 0)
                    {
                        parentNode = foundNode;
                    }

                    foundNode = foundNode.Left;
                }
                else
                {
                    if (foundNode.Right != null && comparer.Compare(data, foundNode.Right.Data) == 0)
                    {
                        parentNode = foundNode;
                    }

                    foundNode = foundNode.Right;
                }
            }

            return new BinaryTreeNode<T>[] { foundNode, parentNode };
        }

        public bool Contains(T data)
        {
            if (rootNode == null)
            {
                return false;
            }

            BinaryTreeNode<T>[] node = FindNodeByData(data);
            BinaryTreeNode<T> foundNode = node[0];
            BinaryTreeNode<T> parentNode = node[1];

            return foundNode != null;
        }

        public void DeleteNode(T data)
        {
            if (rootNode == null)
            {
                return;
            }

            BinaryTreeNode<T>[] node = FindNodeByData(data);
            BinaryTreeNode<T> deleteNode = node[0];
            BinaryTreeNode<T> parentNode = node[1];

            if (deleteNode == null)
            {
                return;
            }

            if (deleteNode.Left == null && deleteNode.Right == null)
            {
                if (parentNode == null)
                {
                    rootNode = null;
                    Count--;
                    return;
                }

                if (parentNode.Left != null && comparer.Compare(parentNode.Left.Data, deleteNode.Data) == 0)
                {
                    parentNode.Left = null;
                    Count--;
                }
                else
                {
                    parentNode.Right = null;
                    Count--;
                }
            }
            else if (deleteNode.Left != null && deleteNode.Right == null)
            {
                if (parentNode == null)
                {
                    rootNode = deleteNode.Left;
                    Count--;
                    return;
                }

                if (parentNode.Left != null && comparer.Compare(parentNode.Left.Data, deleteNode.Data) == 0)
                {
                    parentNode.Left = deleteNode.Left;
                    Count--;
                }
                else
                {
                    parentNode.Right = deleteNode.Left;
                    Count--;
                }
            }
            else if (deleteNode.Right != null && deleteNode.Left == null)
            {
                if (parentNode == null)
                {
                    rootNode = deleteNode.Right;
                    Count--;
                    return;
                }

                if (parentNode.Left != null && comparer.Compare(parentNode.Left.Data, deleteNode.Data) == 0)
                {
                    parentNode.Left = deleteNode.Right;
                    Count--;
                }
                else
                {
                    parentNode.Right = deleteNode.Right;
                    Count--;
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
                Count--;
                parentMinimumNode.Left = minimumNode.Right;
            }

        }

        public IEnumerable<T> GetAroundInWide()
        {
            BinaryTreeNode<T> node = rootNode;

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
            return GetAroundInDeepWithRecursion(rootNode);
        }

        private IEnumerable<T> GetAroundInDeepWithRecursion(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            yield return node.Data;

            if (node.Left != null)
            {
                foreach (var item in GetAroundInDeepWithRecursion(node.Left))
                {
                    yield return item;
                }
            }

            if (node.Right != null)
            {
                foreach (var item in GetAroundInDeepWithRecursion(node.Right))
                {
                    yield return item;
                }
            }
        }

        public IEnumerable<T> GetAroundInDeepWithoutRecursion()
        {
            BinaryTreeNode<T> node = rootNode;

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
