using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sam Green/AI/Actions/PatrolAction")]
public class PatrolAction : AIAction
{
    public override void Execute(AIBase AIbase)
    {
        if (Vector3.Distance(AIbase.transform.position, AIbase.Enemy.target) < 2)
        {
            UpdateDestination(AIbase.Enemy);
        } 
    }
    
    public void UpdateDestination(Enemy e)
    {
        e.index++;
        if (e.index == e.Waypoints.Count)
        {
            e.index = 0;
        }

        e.target =  e.Waypoints[e.index].position;
        e.agent.SetDestination(e.target);
    }


    public override void Init(AIBase AIbase)
    {
        AIbase.Enemy.agent.isStopped = false;
        UpdateDestination(AIbase.Enemy);
    }
}
