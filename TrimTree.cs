using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code
{
    class TrimTree
    {
        public static void Main(string[] args)
        {
            BTreeNode<int> r = new BTreeNode<int>(8);
            r.AddLeftNode(new BTreeNode<int>(3));
            r.AddRightNode(new BTreeNode<int>(10));
            r.Left.AddLeftNode(new BTreeNode<int>(1));
            r.Left.AddRightNode(new BTreeNode<int>(6));
            r.Left.Right.AddLeftNode(new BTreeNode<int>(4));
            r.Left.Right.AddRightNode(new BTreeNode<int>(7));
            r.Right.AddRightNode(new BTreeNode<int>(14));
            r.Right.Right.AddLeftNode(new BTreeNode<int>(13));
            Console.WriteLine(r.PrintInOrder());
            BTreeNode<int> s = trimTree(r, 5, 13);
            
            Console.WriteLine(s.PrintInOrder());
        }

        public static BTreeNode<int> trimTree(BTreeNode<int> b, int min, int max)
        {
            if (b == null) return null;
            if (b.Value < min) return trimTree(b.Right, min, max);
            if (b.Value > max) return trimTree(b.Left, min, max);

            // min <= b.Value <= max
            b.Left = trimTree(b.Left, min, max);
            b.Right = trimTree(b.Right, min, max);

            return b;
        }
    }
}
