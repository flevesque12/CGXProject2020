using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharController : MonoBehaviour
{
    public float m_Speed = 7.5f;
    public float m_Gravity = 20.0f;
    public float m_JumpSpeed = 8.0f;
    public Transform m_PlayerCameraParent;
    public float m_LookSpeed = 2.0f;
    public float m_LookXLimit = 60.0f;

    CharacterController m_CharacterController;
    Vector3 m_MoveDirection = Vector3.zero;
    Vector2 m_Rotation = Vector2.zero;
    private ControllerColliderHit m_Contact;

    [HideInInspector]
    public bool m_CanMoveCharacter = true;

    // Start is called before the first frame update
    void Start()
    {

        m_CharacterController = GetComponent<CharacterController>();
        m_Rotation.y = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (m_CharacterController.isGrounded)
        {
            

            Vector3 forwardDirection = transform.TransformDirection(Vector3.forward);
            Vector3 rightDirection = transform.TransformDirection(Vector3.right);
            float currentSpeedX = m_CanMoveCharacter ? m_Speed * Input.GetAxis("Vertical") : 0;
            float currentSpeedZ = m_CanMoveCharacter ? m_Speed * Input.GetAxis("Horizontal") : 0;

            //apply to the direction
            m_MoveDirection = (forwardDirection * currentSpeedX) + (rightDirection * currentSpeedZ);

            if (Input.GetButton("Jump") && m_CanMoveCharacter)
            {
                m_MoveDirection.y = m_JumpSpeed;
            }
        }
        
        //apply gravity
        m_MoveDirection.y -= m_Gravity * Time.deltaTime;


        m_CharacterController.Move(m_MoveDirection * Time.deltaTime);
        
        if (m_CanMoveCharacter)
        {
            m_Rotation.y += Input.GetAxis("Mouse X") * m_LookSpeed;
            m_Rotation.x += -Input.GetAxis("Mouse Y") * m_LookSpeed;
            m_Rotation.x = Mathf.Clamp(m_Rotation.x, -m_LookXLimit, m_LookXLimit);
            m_PlayerCameraParent.localRotation = Quaternion.Euler(m_Rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, m_Rotation.y);
        }
        
    }
}
