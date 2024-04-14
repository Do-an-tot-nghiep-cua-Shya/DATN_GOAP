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
        SubGoal s3 = new SubGoal("isHome", 1, true);
        goals.Add(s3, 1);
        SubGoal s4 = new SubGoal("relief", 1, true);
        goals.Add(s4, 4);

        Invoke("NeedRelief", Random.Range(12, 15));
    }

    void NeedRelief()
    {
        beliefs.ModifyState("busting", 0);
        Invoke("NeedRelief", Random.Range(12, 15));
    }
}
