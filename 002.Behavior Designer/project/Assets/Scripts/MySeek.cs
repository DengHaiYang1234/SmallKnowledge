using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MySeek : Action
{
    public float speed;
    public SharedTransform target;
    public float arriveDistance = 0.1f;
    private float sqrArriveDistance;
    public override void OnStart()
    {
        sqrArriveDistance = arriveDistance*arriveDistance;
    }

    public override TaskStatus OnUpdate()
    {
        if (target == null || target.Value == null)
            return TaskStatus.Failure;

        transform.LookAt(target.Value.position);
        transform.position =  Vector3.MoveTowards(transform.position, target.Value.position, speed*Time.deltaTime);

        //sqrMagnitude: 求得的距离不开根号（开根号消耗性能）
        if ((target.Value.position - transform.position).sqrMagnitude < sqrArriveDistance)
            return TaskStatus.Success;

        return TaskStatus.Running;

    }

}
