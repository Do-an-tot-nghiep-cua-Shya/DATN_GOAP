using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobberBehaviour : BTAgent
{
    public GameObject door;
    public GameObject toilet;
    public GameObject waitingArea;

    public override void Start()
    {
        base.Start();

        // Define leaf nodes for each destination
        Leaf goToDoor = new Leaf("Go to Door", GoToDoor, 1);
        Leaf goToWaitingRoom = new Leaf("Go to Waiting Room", GoToWaitingRoom, 2);
        Leaf goToToilet = new Leaf("Go to Toilet", GoToToilet, 3);

        // Create a random selector to choose one of the destinations
        RSelector selectLocation = new RSelector("Select Location to Go");
        selectLocation.AddChild(goToDoor);
        selectLocation.AddChild(goToWaitingRoom);
        selectLocation.AddChild(goToToilet);

        // Add the random selector to the behavior tree
        tree.AddChild(selectLocation);

        // Print the tree structure for debugging purposes
        tree.PrintTree();
    }

    // Methods for going to each location
    private BTNode.Status GoToToilet()
    {
        return GoToLocation(toilet.transform.position);
    }

    private BTNode.Status GoToWaitingRoom()
    {
        return GoToLocation(waitingArea.transform.position);
    }

    private BTNode.Status GoToDoor()
    {
        return GoToLocation(door.transform.position);
    }
}
