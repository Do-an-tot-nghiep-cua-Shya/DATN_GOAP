using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : GAction
{
    public override bool  PrePerform()
    {
        beliefs.RemoveState("atHospital");
        return true;
    }
    public override bool  PostPerform()
    {
        Destroy(this.gameObject);
        Spawner.Instance.currentPatients--;
        return true;
    }
}
