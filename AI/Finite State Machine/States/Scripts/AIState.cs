                                                            using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sam Green/AI/States/State")]
public class AIState : BaseAIState
{
    public List<AIAction> AIActions = new List<AIAction>();
    public List<AITransition> AITransitions = new List<AITransition>();

    public override void Execute(AIBase AI)
    {
        foreach (var action in AIActions)
            action.Execute(AI);
        foreach (var transition in AITransitions)
            transition.Execute(AI);
    }
}
