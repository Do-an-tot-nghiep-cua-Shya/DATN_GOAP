using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node
{
    public Node parent;
    public float cost;
    public Dictionary<string, int> state;
    public GAction action;

    public Node(Node parent, float cost, Dictionary<string, int> allstates, GAction action)
    {
        this.parent = parent;
        this.cost = cost;
        this.state = new Dictionary<string, int>(allstates);
        this.action = action;
    }
}
public class GPlanner
{
    public Queue<GAction> plan(List<GAction> actions, Dictionary<string, int> goal, WorldStates states)
    {
        List<GAction> usableAction = new List<GAction>();
        foreach (GAction action in actions)
        {
            if (action.IsAchivable())
            {
                usableAction.Add(action);
            }
        }
        List<Node> leaves = new List<Node>();
        Node start = new Node(null, 0, GWorld.Instance.GetWorld().GetState(), null);

        bool success = BuildGraph(start, leaves, usableAction, goal);
        if (!success)
        {
            Debug.Log("No plan");
            return null;
        }

        Node cheapest = null;
        foreach (Node leaf in leaves)
        {
            if (cheapest == null)
            {
                cheapest = leaf;
            }
            else
            {
                if (leaf.cost < cheapest.cost)
                {
                    cheapest = leaf;
                }
            }
        }
        List<GAction> result = new List<GAction>();
        Node n = cheapest;
        while (n != null)
        {
            if (n.action != null)
            {
                result.Insert(0, n.action);
            }
            n = n.parent;
        }

        Queue<GAction> queue = new Queue<GAction>();
        foreach (GAction action in result)
        {
            queue.Enqueue(action);


            Debug.Log("The plan is: ");
        }
        foreach (GAction action in queue)
        {
            Debug.Log(action.actionName);
        }
        return queue;
    }

    private bool BuildGraph(Node parent, List<Node> leaves, List<GAction> usableActions, Dictionary<string,int> goal)
    {
        bool foundPath = false;
        foreach(GAction action in usableActions)
        {
            if (action.IsAchivableGiven(parent.state))
            {
                Dictionary<string, int> currentState = new Dictionary<string, int>(parent.state);
                foreach(KeyValuePair<string, int> effect in action.effects)
                {
                    if (!currentState.ContainsKey(effect.Key))
                    {
                        currentState.Add(effect.Key, effect.Value);
                    }
                }

                Node node = new Node(parent, parent.cost + action.cost, currentState, action);
                if(GoalAchived(goal, currentState))
                {
                    leaves.Add(node);
                    foundPath = true;
                }
                else
                {
                    List<GAction> subset = ActionSubset(usableActions, action);
                    bool found = BuildGraph(node, leaves, subset, goal);
                    if(found)
                    {
                        foundPath = true;
                    }
                }
            }
        }
        return foundPath;
    }

    private List<GAction> ActionSubset(List<GAction> actions, GAction removeAction)
    {
        List<GAction> subset = new List<GAction>();
        foreach (GAction action in actions)
        {
            if (!action.Equals(removeAction))
            {
                subset.Add(action);
            }
        }
        return subset;
    }

    private bool GoalAchived(Dictionary<string, int> goal, Dictionary<string, int> state)
    {
        foreach(KeyValuePair<string, int> g in goal)
        {
            if (!state.ContainsKey(g.Key))
            {
                return false;
            }
        }
        return true;
    }
}
