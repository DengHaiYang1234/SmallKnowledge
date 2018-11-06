using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class MyCanSeeObject : Conditional
{
    public Transform[] targets;
    public float fieldOfViewAngle = 90;
    //public float viewDistance = 7;

    public SharedFloat sharedViewDistance = 7;

    public SharedTransform target;

    public override TaskStatus OnUpdate()
    {
        if (targets == null)
            return TaskStatus.Failure;

        foreach (var target in targets)
        {
            float distance = (target.position - transform.position).magnitude;
            //两个向量的夹角 z向量与目标向量的夹角
            float angle = Vector3.Angle(transform.forward, target.position - transform.position);

            //目标与z轴的夹角要小于  可是角度的一半
            if (distance < sharedViewDistance.Value && angle < fieldOfViewAngle*0.5f)
            {
                this.target.Value = target;
                return TaskStatus.Success;
            }
                

        }
        return TaskStatus.Failure;
    }

}
