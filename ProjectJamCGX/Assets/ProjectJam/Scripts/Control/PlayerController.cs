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
    private NavMeshAgent agent;
    public bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
       agent  = GetComponent<NavMeshAgent>();


    }


    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                agent.destination = hit.point;
            }
        }

        if(agent.remainingDistance <= agent.stoppingDistance)
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
