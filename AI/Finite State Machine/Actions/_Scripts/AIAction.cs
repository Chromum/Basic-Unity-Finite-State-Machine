using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : ScriptableObject
{
    public abstract void Execute(AIBase AIbase);
    public abstract void Init(AIBase AIbase);
}
