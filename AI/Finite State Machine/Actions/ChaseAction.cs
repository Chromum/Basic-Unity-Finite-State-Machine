using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sam Green/AI/Actions/Chase")]
public class ChaseAction : AIAction
{
    public override void Init(AIBase AIbase)
    {
        
    }

    public override void Execute(AIBase AIbase)
    {

        if (Vector3.Distance(AIbase.transform.position, AIbase.Enemy.player.position) >=
            AIbase.Enemy.Stats.StoppingDistance)
        {
            AIbase.Enemy.agent.isStopped = false;
            AIbase.Enemy.target = AIbase.Enemy.player.position;
            AIbase.Enemy.agent.SetDestination(AIbase.Enemy.target);
            AIbase.Enemy.transform.LookAt(AIbase.Enemy.target);
            AIbase.Enemy.fov.viewAngle = 359;
        }
        else
        {
            AIbase.Enemy.agent.isStopped = true;
            AIbase.Enemy.fov.viewAngle = AIbase.Enemy.fov.startingViewAngle;
        }
    }
}
