using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resigter : GAction
{
    public override bool PostPerform()
    {
        beliefs.ModifyState("atHospital", 0);
        return true;
    }

    public override bool PrePerform()
    {
        return true;
    }

  
}
