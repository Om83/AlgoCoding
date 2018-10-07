using System.Text;

namespace CodePractice
{
    public class TreeNode
    {
        public int data;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { data = x; }
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
} 
