using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        //SubGoal s0 = new SubGoal("hasArrived",1, true);
        //goals.Add(s0,5 );
        SubGoal s1 = new SubGoal("treatPatient", 1, true);
        goals.Add(s1, 3);
        //SubGoal s1 = new SubGoal("hasRegistered", 1, true);
        //goals.Add(s1, 4);
       
    }
}
