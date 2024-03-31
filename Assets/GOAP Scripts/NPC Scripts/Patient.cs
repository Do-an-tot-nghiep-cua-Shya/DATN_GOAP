using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        //SubGoal s0 = new SubGoal("hasArrived",1, true);
        //goals.Add(s0,5 );
        SubGoal s1 = new SubGoal("isWaiting", 1, true);
        goals.Add(s1, 3);
        SubGoal s2 = new SubGoal("isTreated", 1, true);
        goals.Add(s2, 5);


    }
}
