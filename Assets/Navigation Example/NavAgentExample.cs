using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavAgentExample : MonoBehaviour
{
    public AIWaypointNetwork waypointNetwork = null;
    public int currentIndex = 0; // the current target waypoint 

    private NavMeshAgent navAgent = null;


    // Start is called before the first frame update
    void Start()
    {
        // Cashe NavMeshAgent Reference
        navAgent = this.GetComponent<NavMeshAgent>();
        if (waypointNetwork == null) return;  // exit of this script if a network is not assigned

        if(waypointNetwork.waypoints[currentIndex] != null)
        {
            navAgent.destination = waypointNetwork.waypoints[currentIndex].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
