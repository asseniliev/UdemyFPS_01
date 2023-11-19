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
        this.navAgent = this.GetComponent<NavMeshAgent>();
        if (this.waypointNetwork == null) return;  // exit of this script if a network is not assigned

        SetNextDestination(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetNextDestination(bool increment)
    {
        if (!this.waypointNetwork) return;

        int incStep = increment ? 1 : 0; // The increment step is 1 or 0, depending in the 'increment' parameter
        Transform nextWaypointTransform = null;

        while (nextWaypointTransform == null)
        {
            int nextWaypont = (this.currentIndex + incStep >= this.waypointNetwork.waypoints.Count) ? 0 : this.currentIndex + incStep;
            nextWaypointTransform = this.waypointNetwork.waypoints[nextWaypont];
            
            if(nextWaypointTransform != null)
            {
                this.currentIndex = nextWaypont;
                this.navAgent.destination = nextWaypointTransform.position;
                return;
            }
            currentIndex++;
        }
    }
}
