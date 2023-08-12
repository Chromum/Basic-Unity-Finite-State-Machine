using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sam Green/AI/Transitions/Transition")]
public class AITransition : ScriptableObject
{
    public AIDecision Decision;
    public AIState TrueState;
    public AIState FalseState;

    public virtual void Execute(AIBase aiBase)
    {
        if (Decision.Decide(aiBase))
        {
            if (!(TrueState is RemainInState))
            {
                aiBase.CurrentState = TrueState;
                foreach (var VARIABLE in FalseState.AIActions)
                {
                    VARIABLE.Init(aiBase); // Run the Init method of the new state
                }            
            }
        }
        else
        {
            if (!(FalseState is RemainInState))
            {
                aiBase.CurrentState = FalseState;
                foreach (var VARIABLE in FalseState.AIActions)
                {
                    VARIABLE.Init(aiBase); // Run the Init method of the new state
                }
            }
        }
    }
}
