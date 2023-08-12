using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class StopOnCollision : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool obstacleDetected = false;
    private float initialRayDistance = 1.0f;
    public float maxRayDistance = 5.0f;
    private float turnAngle = 180f;
    public bool isAI;
    private float currentRayDistance;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (agent.enabled)
        {
            currentRayDistance = maxRayDistance;

            GameObject g = null;
            if (IsObstacleInFront(currentRayDistance, out g))
            {
                obstacleDetected = true;
                agent.isStopped = true;
                agent.SetDestination(agent.transform.position);
                // Rotate the agent away from the obstacle
                Vector3 newDirection = Quaternion.Euler(0, turnAngle, 0) * agent.transform.forward;
                agent.transform.rotation = Quaternion.LookRotation(newDirection);
                
            }
            else
            {
                obstacleDetected = false;
                agent.isStopped = false;
            }
        }
    }
    private bool IsObstacleInFront(float rayDistanceout, out GameObject gameObject)
    {
        RaycastHit hit;
        if (Physics.Raycast(agent.transform.position, agent.transform.forward, out hit, rayDistanceout))
        {
            gameObject = hit.collider.gameObject;
            return hit.collider.CompareTag("Obstacle");
        }

        gameObject = null;
        return false;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward*currentRayDistance);
    }
}