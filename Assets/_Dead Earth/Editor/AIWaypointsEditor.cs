using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (AIWaypointNetwork))]
public class AIWaypointsEditor : Editor
{
    private void OnSceneGUI()
    {
        AIWaypointNetwork network = (AIWaypointNetwork)this.target;
        for (int i = 0; i < network.waypoints.Count; i++)
        {
            Handles.Label(network.waypoints[i].position, "Waipoint" + (i+1).ToString());
        }
    }
}
