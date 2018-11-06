using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IsHasFlag : Conditional
{
    private Offense offense;

    public override void OnAwake()
    {
        offense = this.GetComponent<Offense>();
    }

    public override TaskStatus OnUpdate()
    {
        if (offense.hasFlag)
            return TaskStatus.Success;
        return TaskStatus.Failure;
    }

}
