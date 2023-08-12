using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBase : MonoBehaviour
{
    public Enemy Enemy;
    [SerializeField] public AIState initialState;

    private void Start()
    {
        CurrentState = initialState;
        foreach (var VARIABLE in CurrentState.AIActions)
        {
            VARIABLE.Init(this);
        }
    }

    public AIState CurrentState;

    public void Update()
    {
        CurrentState.Execute(this);
    }

    public void ChangeState(AIState state)
    {
        CurrentState = state;
        foreach (var VARIABLE in CurrentState.AIActions)
        {
            VARIABLE.Init(this);
        }
    }
}
    
