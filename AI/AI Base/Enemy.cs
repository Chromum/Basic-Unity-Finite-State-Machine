using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy :  MonoBehaviour
{
    public EnemyStats Stats;
    [HideInInspector]public NavMeshAgent agent;
    public Transform player;
    [HideInInspector]private AIBase AIbase;
    public List<Transform> Waypoints = new List<Transform>();
    [HideInInspector] public int index;
    public Vector3 target;
    public Transform targetObject;
    [HideInInspector] public FieldOfView fov;



    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        AIbase = gameObject.GetComponent<AIBase>();
        fov = GetComponent<FieldOfView>();
    }

    void Update()
    {
    }

    public void Investigate(Vector3 pos)
    {
        target = pos;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (Waypoints == null || Waypoints.Count < 2)
            return;

        for (int i = 0; i < Waypoints.Count - 1; i++)
        {
            Gizmos.DrawLine(Waypoints[i].position, Waypoints[i + 1].position);
        }

        // Draw a line from the last point back to the first point to complete the route.
        Gizmos.DrawLine(Waypoints[Waypoints.Count - 1].position, Waypoints[0].position);
        
        if (agent == null || agent.path == null)
            return;

        Handles.color = Color.blue;

        Vector3[] pathCorners = agent.path.corners;

        for (int i = 0; i < pathCorners.Length - 1; i++)
        {
            Handles.DrawLine(pathCorners[i], pathCorners[i + 1]);
        }
    }

    
}
