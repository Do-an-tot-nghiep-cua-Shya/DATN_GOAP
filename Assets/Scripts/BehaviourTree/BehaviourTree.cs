using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : BTNode
{
    public BehaviourTree()
    {
        name = "Tree";
    }

    public BehaviourTree(string n)
    {
        name = n;
    }

    public override Status Process()
    {
        if (children.Count == 0) return Status.SUCCESS;
        return children[currentChild].Process();
    }


    struct BTNodeLevel
    {
        public int level;
        public BTNode BTNode;
    }

    public void PrintTree()
    {
        string treePrintout = "";
        Stack<BTNodeLevel> BTNodeStack = new Stack<BTNodeLevel>();
        BTNode currentBTNode = this;
        BTNodeStack.Push(new BTNodeLevel { level = 0, BTNode = currentBTNode } );

        while (BTNodeStack.Count != 0)
        {
            BTNodeLevel nextBTNode = BTNodeStack.Pop();
            treePrintout += new string('-', nextBTNode.level) + nextBTNode.BTNode.name + "\n";
            for (int i = nextBTNode.BTNode.children.Count - 1; i >= 0; i--)
            {
                BTNodeStack.Push( new BTNodeLevel { level = nextBTNode.level + 1, BTNode = nextBTNode.BTNode.children[i] });
            }
        }

        Debug.Log(treePrintout);

    }

}
