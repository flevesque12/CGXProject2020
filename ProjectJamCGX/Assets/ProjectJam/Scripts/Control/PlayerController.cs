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
    public bool isRunning = false;
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
        
        if(m_Agent.remainingDistance <= m_Agent.stoppingDistance)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }
    }
        
    

   


    private void Interaction()
    {

    }
}
