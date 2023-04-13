using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMover : MonoBehaviour
{
    [Range(5f, 15f)]
    [SerializeField] private float followRange = 10f;

    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float moveSpeed = 5f;
    private Transform currentWaypoint;

    public NavMeshAgent agent;
    public Transform player;
    public Transform companion;
    public float playerToCompanionDistance;
    public float waypointToCompanionDistance;
    public float playerToWaypointDistance;

    //draws the radius around the player showing how far the companion with move away from it
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(player.position, followRange);
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(target.position, followRange * 2);
    }

    private void Start()
    {
        //sets initial waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;
        //sets next waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
    }


    void Update()
    {
        //aims the companion at the current waypoint target
        agent.SetDestination(currentWaypoint.transform.position);
        //sets agent speed to a variable
        agent.speed = moveSpeed;

        //calculates the distance from the player and the companion
        playerToCompanionDistance = Vector3.Distance(companion.transform.position, player.transform.position);
        //calculates the distance from the companion and the current waypoint
        waypointToCompanionDistance = Vector3.Distance(companion.transform.position, currentWaypoint.transform.position);
        //calculates the distance from the player and the current waypoint
        playerToWaypointDistance = Vector3.Distance(player.transform.position, currentWaypoint.transform.position);

        //stops the companion if they travel far enough from the player
        if (playerToCompanionDistance > followRange)
        {
            agent.speed = 0;
            //Debug.Log("stopped");
        }
        /*
        else if(playerToCompanionDistance > followRange * 2)
        {
            agent.speed = moveSpeed;
            agent.SetDestination(currentWaypoint.transform.position);
            Debug.Log("too far");
        }
        */
        else
        {
            agent.speed = moveSpeed;
            //agent.SetDestination(currentWaypoint.transform.position);
            //Debug.Log("rolling");
        }


        //if the companion is close enough to the current waypoint it's heading towards, it will switch to the next waypoint and repeat
        if (waypointToCompanionDistance < 0.2f && playerToCompanionDistance < followRange / 2)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);

        }
        //speeds the companion up if the player is ahead of it
        else if (playerToWaypointDistance < waypointToCompanionDistance)
        {
            agent.speed = moveSpeed * 2;
        }

    }


}
