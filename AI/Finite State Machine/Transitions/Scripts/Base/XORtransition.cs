using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sam Green/AI/Transitions/XORTransition")]
public class XORtransition : AITransition
{
    public AIDecision NotDecision;

    public override void Execute(AIBase aiBase)
    {
        if ((Decision.Decide(aiBase) ^ NotDecision.Decide(aiBase)) && !(TrueState is RemainInState))
            aiBase.CurrentState = TrueState;
        else if (!(FalseState is RemainInState))
            aiBase.CurrentState = FalseState;
    }
}
