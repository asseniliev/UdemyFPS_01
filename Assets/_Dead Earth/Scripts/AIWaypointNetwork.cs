using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PathDisplayMode
{
    None, Connections, Paths
}

public class AIWaypointNetwork : MonoBehaviour
{
    public PathDisplayMode displayMode = PathDisplayMode.Connections;
    public int uiStart = 0;
    public int uiEnd = 0;
    public List<Transform> waypoints = new List<Transform>();
}
