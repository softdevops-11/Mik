using System;
using System.Collections.Generic;

namespace BinaryTree
{
    internal class BinaryTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> RootNode { get; set; }

        public BinaryTree(T data)
        {
            RootNode = new BinaryTreeNode<T>(data);
        }

        public BinaryTreeNode<T> Add(T data, BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                node = new BinaryTreeNode<T>(data);
            }
            else
            {
                if (data.CompareTo(node.Data) < 0)
                {
                    node.Left = Add(data, node.Left);
                    node.Left.Parent = node;
                }
                else
                {
                    node.Right = Add(data, node.Right);
                    node.Right.Parent = node;
                }
            }

            return node;
        }

        public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> node)
        {
            if (node == null || data.CompareTo(node.Data) == 0)
            {
                return node;
            }
            else
            {
                if (data.CompareTo(node.Data) < 0)
                {
                    return FindNode(data, node.Left);
                }
                else
                {
                    return FindNode(data, node.Right);
                }
            }
        }

        public void DeleteNode(T data)
        {
            BinaryTreeNode<T> deleteNode = FindNode(data, RootNode);

            if (deleteNode == null)
            {
                return;
            }

            if (deleteNode.Parent == null && deleteNode.Left == null && deleteNode.Right == null)
            {
                RootNode = null;
                return;
            }

            if (deleteNode.Left == null && deleteNode.Right == null)
            {
                if (deleteNode.Parent.Left != null && deleteNode.Parent.Left.Data.CompareTo(deleteNode.Data) == 0)
                {
                    deleteNode.Parent.Left = null;
                }
                else
                {
                    deleteNode.Parent.Right = null;
                }
            }
            else if (deleteNode.Left != null && deleteNode.Right == null)
            {
                if (deleteNode.Parent == null)
                {
                    RootNode = deleteNode.Left;
                    RootNode.Parent = null;
                    return;
                }

                if (deleteNode.Parent.Left != null && deleteNode.Parent.Left.Data.CompareTo(deleteNode.Data) == 0)
                {
                    deleteNode.Parent.Left = deleteNode.Left;
                }
                else
                {
                    deleteNode.Parent.Right = deleteNode.Left;
                }

                deleteNode.Left.Parent = deleteNode.Parent;
            }
            else if (deleteNode.Right != null && deleteNode.Left == null)
            {
                if (deleteNode.Parent == null)
                {
                    RootNode = deleteNode.Right;
                    RootNode.Parent = null;
                    return;
                }

                if (deleteNode.Parent.Left != null && deleteNode.Parent.Left.Data.CompareTo(deleteNode.Data) == 0)
                {
                    deleteNode.Parent.Left = deleteNode.Right;
                }
                else
                {
                    deleteNode.Parent.Right = deleteNode.Right;
                }

                deleteNode.Right.Parent = deleteNode.Parent;
            }
            else
            {
                BinaryTreeNode<T> minimumNode = deleteNode.Right;

                while (minimumNode.Left != null)
                {
                    minimumNode = minimumNode.Left;
                }

                BinaryTreeNode<T> temp = minimumNode;

                if (minimumNode.Right != null)
                {
                    minimumNode = minimumNode.Right;
                    temp.Parent = deleteNode.Parent;
                    temp.Left = deleteNode.Left;
                    temp.Left.Parent = temp;
                }
                else
                {
                    minimumNode.Parent.Left = null;
                    temp.Parent = deleteNode.Parent;
                    temp.Left = deleteNode.Left;
                    temp.Right = deleteNode.Right;
                    temp.Left.Parent = temp;
                    temp.Right.Parent = temp;
                }

                if (deleteNode.Parent == null)
                {
                    RootNode = temp;
                    return;
                }

                if (deleteNode.Parent.Left != null && deleteNode.Parent.Left.Data.CompareTo(deleteNode.Data) == 0)
                {
                    deleteNode.Parent.Left = temp;
                }
                else
                {
                    deleteNode.Parent.Right = temp;
                }
            }
        }

        public int GetCountNodes(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int count = 1;
                count += GetCountNodes(node.Left);
                count += GetCountNodes(node.Right);
                return count;
            }
        }

        public string GetAroundInWide(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return default;
            }

            Queue<BinaryTreeNode<T>> quene = new Queue<BinaryTreeNode<T>>();
            quene.Enqueue(node);
            string stringWide = "";

            while (quene.Count != 0)
            {
                node = quene.Dequeue();
                stringWide += " узел " + node.Data;

                if (node.Left != null)
                {
                    quene.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    quene.Enqueue(node.Right);
                }
            }

            return stringWide;
        }

        public string GetAroundInDeepWithRecursion(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return default;
            }
            else
            {
                string stringDeep = "";
                stringDeep += " узел " + node.Data;
                stringDeep += GetAroundInDeepWithRecursion(node.Left);
                stringDeep += GetAroundInDeepWithRecursion(node.Right);
                return stringDeep;
            }
        }

        public string GetAroundInDeepWithoutRecursion(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return default;
            }

            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(node);
            string stringDeep = "";

            while (stack.Count != 0)
            {
                node = stack.Pop();
                stringDeep += " узел " + node.Data;

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }

            return stringDeep;
        }
    }
}
