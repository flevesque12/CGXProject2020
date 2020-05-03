using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    #region Variables
    //variables

    private Camera m_Cam;
    [Header("Target")]
    private Transform m_Player;
    [Header("Distance")]
    [Range(2f, 5f)]
    public float distance = 4f;
    public float minDistance = 3f;
    public float maxDistance = 5f;

    [Header("Speed")]
    private float smoothSpeed = 5f;
    private float scrollSensivity = 1f;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (!m_Player)
        {
            //print("No target for camera");
            return;
        }

        float num = Input.GetAxis("Mouse ScrollWheel");
        distance -= num * scrollSensivity;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        //m_Cam.orthographicSize = distance;

        Vector3 _pos = m_Player.position;
        _pos -= transform.forward * distance;

        transform.position = Vector3.Lerp(transform.position, _pos, smoothSpeed * Time.deltaTime);

    }
}
