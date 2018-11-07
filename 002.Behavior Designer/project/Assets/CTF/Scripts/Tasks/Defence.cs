using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime.Tasks;


//用来追击敌人,至到丢失视野
public class Defence : Action
{
    public SharedFloat viewDistance;
    public SharedFloat fieldOfViewAngle;

    public SharedFloat speed;
    public SharedFloat angularSpeed;


    public SharedGameObject target;

    private float sqrViewDistance;
    private NavMeshAgent navMeshAgent;




    public override void OnAwake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    public override void OnStart()
    {
        sqrViewDistance = viewDistance.Value*viewDistance.Value;
        navMeshAgent.enabled = true;
        navMeshAgent.speed = speed.Value;
        navMeshAgent.angularSpeed = angularSpeed.Value;
        navMeshAgent.destination = target.Value.transform.position;
    }

    public override TaskStatus OnUpdate()
    {
        if (target == null || target.Value == null)
            return TaskStatus.Success;

        float sqrDistance = (target.Value.transform.position - transform.position).sqrMagnitude;
        float angle = Vector3.Angle(transform.forward, target.Value.transform.position - transform.position);
        if (sqrDistance < sqrViewDistance && angle < fieldOfViewAngle.Value*0.5f)
        {
            //目标处于视野范围内
            if (navMeshAgent.destination != target.Value.transform.position)
            {
                navMeshAgent.destination = target.Value.transform.position;
            }
            return TaskStatus.Running;
        }
        //目标脱离视野范围
        else
            return TaskStatus.Success;
    }

    public override void OnEnd()
    {
        //navMeshAgent.enabled = false;
    }
}
