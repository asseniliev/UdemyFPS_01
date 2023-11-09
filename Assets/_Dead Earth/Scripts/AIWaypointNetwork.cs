using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PathDisplayMode
{
    None, Connections, Paths
}

public class AIWaypointNetwork : MonoBehaviour
{
    [HideInInspector]
    public PathDisplayMode displayMode = PathDisplayMode.Connections;
    [HideInInspector]
    public int uiStart = 0;
    [HideInInspector]
    public int uiEnd = 0;

    public List<Transform> waypoints = new List<Transform>();

}
