using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public float m_TurnSpeed = 4.0f;
    public float m_MinTurnAngle = -90;
    public float m_MaxTurnAngle = 0;

    public float m_MaxDistance = 100.0f;
    public float m_MinDistance = 0f;

    public Transform m_Target;

    private float m_TargetDistance;
    private float m_RotX;

    // Start is called before the first frame update
    void Start()
    {
        //m_Target.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        m_TargetDistance = Vector3.Distance(transform.position, m_Target.position);
    }

    // Update is called once per frame
    void Update()
    {
        //mouse input
        float mouseY = Input.GetAxis("Mouse X") * m_TurnSpeed;
        m_RotX += Input.GetAxis("Mouse Y") * m_TurnSpeed;

        //limit the vertical rotation
        m_RotX = Mathf.Clamp(m_RotX, m_MinTurnAngle, m_MaxTurnAngle);

        //rotate the camera
        transform.eulerAngles = new Vector3(-m_RotX, transform.eulerAngles.y + mouseY, 0);

        transform.position = m_Target.position - (transform.forward * m_TargetDistance);
    }
}
