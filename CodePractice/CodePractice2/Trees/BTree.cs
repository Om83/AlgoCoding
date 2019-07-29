using System;
using System.Collections.Generic;

namespace CodePractice2
{
    public class TreeNode
    {
        public char data;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(char x) { data = x; }
    }

    public class DLLNode
    {
        public char data;
        public DLLNode prev;
        public DLLNode next;
    }
    class NodeInfo
    {
        public TreeNode Node;
        public string Text;
        public int StartPos;
        public int Size { get { return Text.Length; } }
        public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
        public NodeInfo Parent, Left, Right;
    }
    public static class BTree
    {
        static List<TreeNode> set = new List<TreeNode>();
        static Stack<TreeNode> stack = new Stack<TreeNode>();
        static string joinStr = "'";
        static TreeNode DLLPrev = null;
        public static TreeNode DLLHead;

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        internal static TreeNode BuildBTree(char[] preorder, char[] inorder)
        {
            TreeNode root = null;
            int i = 0;
            if (preorder.Length > 0 && inorder.Length > 0)
            {
                root = new TreeNode(preorder[0]);

                if (preorder.Length == 1 && inorder.Length == 1)
                    return root;

                //find root value in Inorder
                while (inorder[i] != root.data && i < inorder.Length)
                {
                    i++;
                }
            }

            // Generate Inorder Left and Right Subtree child
            char[] leftInorder = inorder.SubArray(0, i);
            char[] rightInorder = inorder.SubArray(i + 1, inorder.Length - i - 1);
            // Generate PreOrder Left and Right Subtree child
            char[] leftPreorder = preorder.SubArray(1, i);
            char[] rightPreorder = preorder.SubArray(i + 1, preorder.Length - i - 1);
            root.left = BuildBTree(leftPreorder, leftInorder);
            root.right = BuildBTree(rightPreorder, rightInorder);
            return root;

        }

        //Do inorder traversal
        //at each node set node->prev= prev; prev->next= node; prev=node;
        //https://www.youtube.com/watch?v=FsxTX7-yhOw
        public static void BTree2DLL(TreeNode node)
        {
            // Base case  
            if (node == null)
            {
                return;
            }

            // Process left subtree
            if (node.left != null)
            {
                BTree2DLL(node.left);
            }

            // Process Node
            if (DLLPrev == null)
            {
                DLLHead = node;
            }
            else
            {
                node.left = DLLPrev;
                DLLPrev.right = node;

            }
            DLLPrev = node;

            // Process right subtree
            if (node.right != null)
            {
                BTree2DLL(node.right);
            }
        }


        //internal static TreeNode BuildBTree(int[] preorder, int[] inorder)
        //{

        //    TreeNode root = null;
        //    int preC = 0;
        //    int inC = 0;

        //    TreeNode node = null;
        //    do
        //    {
        //        node = new TreeNode(preorder[preC]);
        //        if (root == null)
        //        {
        //            root = node;
        //        }
        //        if (!(stack.Count == 0))
        //        {
        //            if (set.Contains(stack.Peek()))
        //            {
        //                set.Remove(stack.Peek());
        //                stack.Pop().right = node;
        //            }
        //            else
        //            {
        //                stack.Peek().left = node;
        //            }
        //        }
        //        stack.Push(node);
        //    }
        //    while (preorder[preC++] != inorder[inC] && preC < preorder.Length);

        //    node = null;
        //    while (!(stack.Count == 0) && inC < inorder.Length && stack.Peek().data == inorder[inC])
        //    {
        //        node = stack.Pop();
        //        inC++;
        //    }

        //    if (node != null)
        //    {
        //        set.Add(node);
        //        stack.Push(node);
        //    }

        //    return root;
        //}

#region PrintHelper


        public static void PrintDLL(TreeNode node)
        {
            if (node == null)
                return;
            while(node!=null)
            {
                Console.Write(node.data );
                if(node.right!=null)
                    Console.Write(" == ");
                node = node.right;
            }
        
        }
        public static void Print(this TreeNode root, int topMargin = 2, int leftMargin = 2)
        {
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            TreeNode next = root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.data.ToString() };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                    }
                }
                next = next.left ?? next.right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos;
                        else
                            item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        // Function to build tree using given traversal 

        private static void Print(NodeInfo item, int top)
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
                PrintLink(top + 1, "/", joinStr, item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null)
                PrintLink(top + 1, joinStr, "\\", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }

        private static void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print(joinStr, top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private static void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }

        private static void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }

#endregion
    }

    public static class BTreeTest
    {
        static TreeNode root = null;
        public static void BuildBTreeFromTwoTraversals()
        {
            char[] inorder = new char[] {'H','D','I','B','J','E','K','A','L','F','M','C','N','G','O'};
            char[] preorder = new char[] {'A','B','D','H','I','E','J','K','C','F','L','M','G','N','O'};
            Console.WriteLine("Inorder Array = {'H','D','I','B','J','E','K','A','L','F','M','C','N','G','O'}");
            Console.WriteLine("PreorderArray={'A','B','D','H','I','E','J','K','C','F','L','M','G','N','O'}");
            Console.WriteLine("\nTree generated from PreOrder and Inorder Arrays is :");
            root = BTree.BuildBTree(preorder, inorder);
            BTree.Print(root);
            Console.WriteLine("\n************************************************************\n");
        }

        public static void BuildDLLFromTree()
        {
            BTree.BTree2DLL(root);
            BTree.PrintDLL(BTree.DLLHead);
        }
    }
} 
