using UnityEngine;
using UnityEngine.AI;

/*
 this is where we interact with input
     */

public class PlayerController : MonoBehaviour
{
    public float m_InteractionRange = 1.0f;
    public bool isRunning = false;
    private CameraRayCaster m_CameraRayCaster;
    private NavMeshAgent m_Agent;
    private Animator m_Animator;

    // Start is called before the first frame update
    private void Start()
    {
        m_CameraRayCaster = Camera.main.GetComponent<CameraRayCaster>();
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            m_Agent.destination = m_CameraRayCaster.Hit.point;
        }

        if (m_Agent.remainingDistance <= m_Agent.stoppingDistance)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }

        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        //get the velocity from the navmesh agent
        Vector3 _velocity = m_Agent.velocity;

        Vector3 localVelocity = transform.InverseTransformDirection(_velocity);
        float _speed = localVelocity.z;
        m_Animator.SetFloat("speed", _speed);
    }

    private void Interaction()
    {
    }
}