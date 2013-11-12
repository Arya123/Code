using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code
{
    

class BinaryTree
{

    public static void Main(string[] args)
    {
        BTreeNode<int> r = new BTreeNode<int>(3);
        r.AddLeftNode(new BTreeNode<int>(1));
        r.AddRightNode(new BTreeNode<int>(4));
        Console.WriteLine(IsBinarySearchTree(r));
    }

    public static bool IsBinarySearchTree(BTreeNode<int> t)
    {
        
        if(t.Left == null && t.Right == null) return true;
        bool isLeft = false, isRight = false;
        if(t.Left!=null)
        {
            if(t.Value >= t.Left.Value) isLeft = IsBinarySearchTree(t.Left);
            else return false;
        }
        if(t.Left!=null)
        {
            if(t.Value < t.Right.Value) isRight = IsBinarySearchTree(t.Right);
            else return false;
        }
    
        return isLeft && isRight;
    }


}

public class BTreeNode<T>
{
    private BTreeNode<T> left = null;
    private BTreeNode<T> right = null;
    private T value;
    
    public BTreeNode<T> Left
    {
        get { return this.left; }
    }
    
    public BTreeNode<T> Right
    {
        get { return this.right; }
    }

    public T Value
    {
        get { return this.value; }
    }

    
    public BTreeNode(BTreeNode<T> left, BTreeNode<T> right, T value)
    {
        this.left = left;
        this.right = right;
        this.value = value;
    }
    
    public BTreeNode(T value)
    {
        this.value = value;
    }

    public bool AddLeftNode(BTreeNode<T> node)
    {
        if(this.left==null)
        {
            this.left = node;
            return true;
        }
        Console.WriteLine("Left node already exists");
        return false;
    }

    public bool AddRightNode(BTreeNode<T> node)
    {
        if(this.right==null)
        {
            this.right = node;
            return true;
        }
        Console.WriteLine("Right node already exists");
        return false;
    }
}



}
