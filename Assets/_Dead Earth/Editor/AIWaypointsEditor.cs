using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

[CustomEditor(typeof (AIWaypointNetwork))]
public class AIWaypointsEditor : Editor
{
    private void OnSceneGUI()
    {
        // The 'target' is the game object to which the 'AIWaypointNetwork' component is attached
        AIWaypointNetwork network = (AIWaypointNetwork)this.target;

        // We assign a lable (via the Handle.Label method) to each view point
        for (int i = 0; i < network.waypoints.Count; i++)
        {
            if(network.waypoints != null)
            {
                Handles.Label(network.waypoints[i].position, "Waipoint" + (i + 1).ToString());
            }            
        }

        if(network.displayMode == PathDisplayMode.Connections)
        {
            // Draw connecting lines between all points, starting from the first, going to the last and back to the first

            Vector3[] linePoints = new Vector3[network.waypoints.Count + 1]; // we want an additional element to represent the first point so that a line connects from the last to the first point as well
                                                                             // Explanation about 'network.waypoints.Count + 1' :
                                                                             // we want an additional element to represent the first point so that a line connects
                                                                             // from the last to the first point as well

            for (int i = 0; i <= network.waypoints.Count; i++)
            {
                int index = i != network.waypoints.Count ? i : 0; // the last viewpoint will be the first in the array
                if (network.waypoints[index] != null)
                {
                    linePoints[i] = network.waypoints[index].position;
                }
                else
                {
                    linePoints[i] = new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);
                }
            }

            //Draw the lines in the scene view:
            Handles.color = Color.cyan;
            Handles.DrawPolyLine(linePoints);
        }
        else if(network.displayMode == PathDisplayMode.Paths)
        {
            // Calculate the navmesh path between two points:
            NavMeshPath path = new NavMeshPath();
            Vector3 from = network.waypoints[network.uiStart - 1].position;
            Vector3 to   = network.waypoints[network.uiEnd - 1].position;

            // Method 'CalculatePath' of the static 'NavMesh' class
            // will return the calculated path in the 'path' parameter
            NavMesh.CalculatePath(from, to, NavMesh.AllAreas, path);

            // The NavMeshPath contains member 'corners' which is a Vector3 array of all
            // the waypoints calculated in the path. We shall use this array of corners as
            // array of view points in the Handle.DrawPolyLine method
            // => Draw the navmesh path netween two viewpoints
            Handles.color = Color.yellow;
            Handles.DrawPolyLine(path.corners);
        }

    }
}
