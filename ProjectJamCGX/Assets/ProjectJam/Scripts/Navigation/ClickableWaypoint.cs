using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableWaypoint : MonoBehaviour
{
    public string waypointName;

    Image imgWaypointLocked;
    Image imgWaypointUnlocked;

    private Vector3 m_WayPointPosition = Vector3.zero;
    //if you want the position of the waypoint in general
    public Vector3 WayPointPosition { get { return this.m_WayPointPosition; } set { this.m_WayPointPosition = value; } }

    bool m_IsWaypointLocked = true;
    //with this we can lock/unlock the player waypoint stage
    public bool IsWaypointLocked { get { return this.m_IsWaypointLocked; } set { this.m_IsWaypointLocked = value; } }

    // Start is called before the first frame update
    void Start()
    {
        this.m_WayPointPosition = transform.position;
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse down:" + m_WayPointPosition);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
}
