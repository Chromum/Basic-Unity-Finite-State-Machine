using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    [HideInInspector]public float startingViewAngle;
    public LayerMask targetMask;
    public LayerMask obsticleMask;

    public List<Transform> visibleTargets = new List<Transform>();

    public void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
        startingViewAngle = viewAngle;
    }

    public IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius ,targetMask);


        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obsticleMask))
                {
                    visibleTargets.Add(target);
                }
            }
        }
        
    }

    public Vector3 DirFromAngle(float angleInDegrees,bool angleGlobal)
    {
        if (!angleGlobal)
            angleInDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    public bool IsVisible(Transform target)
    {
        if (visibleTargets.Contains(target))
            return true;
        else
            return false;
    }


    public void OnDrawGizmos()
    {
        Handles.color = Color.white;
        Handles.DrawWireArc(transform.position,Vector3.up, Vector3.forward,360,viewRadius);
        Vector3 viewAngleA = DirFromAngle(-viewAngle / 2, false);
        Vector3 viewAngleB = DirFromAngle(viewAngle / 2, false);

        Handles.DrawLine(transform.position, transform.position + viewAngleA * viewRadius);
        Handles.DrawLine(transform.position, transform.position + viewAngleB * viewRadius);

        Handles.color = Color.red;
        foreach (var VARIABLE in visibleTargets)
        {
            Handles.DrawLine(transform.position, VARIABLE.transform.position);
        }
    }
}
