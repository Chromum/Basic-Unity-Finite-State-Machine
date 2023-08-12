using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAIState : ScriptableObject
{
    public virtual void Execute(AIBase AI) { }
}
