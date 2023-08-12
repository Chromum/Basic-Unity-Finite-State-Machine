using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sam Green/AI/Transitions/AndTransition")]
public class AndTransition : AITransition
{
    public AIDecision SecondDecision;
    public override void Execute(AIBase aiBase)
    {
        //Debug.Log(base.Decision.Decide(aiBase).ToString());
        //Debug.Log(SecondDecision.Decide(aiBase).ToString());

        if (base.Decision.Decide(aiBase) && SecondDecision.Decide(aiBase) && !(TrueState is RemainInState))
            aiBase.CurrentState = TrueState;
        else if (!(FalseState is RemainInState))
            aiBase.CurrentState = FalseState;
    }   
}
