using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Sam Green/AI/Decisions/Is Player Visible")]
public class IsPlayerVisibleDecision : AIDecision
{
    public override bool Decide(AIBase AIbase)
    {
        if (AIbase.Enemy.fov.IsVisible(AIbase.Enemy.player))
        {
            AIbase.Enemy.targetObject = AIbase.Enemy.player;
            AIbase.Enemy.target = AIbase.Enemy.targetObject.position;
            return true;
        }
        else return false;
    }
}
