using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 this is where we interact with input
     */


public class PlayerController : MonoBehaviour
{
    public float m_InteractionRange = 1.0f;

    CameraRayCaster m_CameraRayCaster;
    NavMeshAgent m_Agent;
    // Start is called before the first frame update
    void Start()
    {
        m_CameraRayCaster = Camera.main.GetComponent<CameraRayCaster>();
        m_Agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
           
                m_Agent.destination = m_CameraRayCaster.Hit.point;
                Debug.Log("Destination");
            
        }
    }


    private void Interaction()
    {

    }
}
