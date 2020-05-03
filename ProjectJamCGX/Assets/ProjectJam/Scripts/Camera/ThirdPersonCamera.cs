using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public float m_TurnSpeed = 4.0f;
    public float m_MinTurnAngle = 1f;
    public float m_MaxTurnAngle = 90f;

    public float m_MaxDistance = 10.0f;
    public float m_MinDistance = 1.5f;
    private float smoothSpeed = 5f;
    public Transform m_Target;

    private float m_TargetDistance;
    private float m_RotX;
    private float m_Distance;
    private float m_MouseY;

    private Vector3 m_Offset;
    // Start is called before the first frame update
    void Start()
    {
        //m_Target.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        m_TargetDistance = Vector3.Distance(transform.position, m_Target.position);
        m_Offset = m_Target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //mouse input
        m_MouseY = Input.GetAxis("Mouse X") * m_TurnSpeed;
        m_RotX += Input.GetAxis("Mouse Y") * m_TurnSpeed;
        m_Distance -= Input.GetAxis("Mouse ScrollWheel");
        

        //limit the vertical rotation and distance
        m_RotX = Mathf.Clamp(m_RotX, m_MinTurnAngle, m_MaxTurnAngle);
        m_Distance = Mathf.Clamp(m_Distance, m_MinDistance, m_MaxDistance);

       
    }

    private void LateUpdate()
    {
        //rotate the camera
        transform.eulerAngles = new Vector3(-m_RotX, transform.eulerAngles.y + m_MouseY, 0);
        //Quaternion rotation = Quaternion.Euler(-m_RotX, transform.eulerAngles.y + m_MouseY, 0f);
        transform.position =  Vector3.Lerp(transform.position, m_Target.position - m_Offset, smoothSpeed * Time.deltaTime);
        transform.LookAt(m_Target.position);
    }
}
