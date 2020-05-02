using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{

    public Transform m_ReferenceTransform;
    public float m_CollisionOffset = 0.2f; //To prevent Camera from clipping through Objects

    Vector3 m_DefaultPos;
    Vector3 m_DirectionNormalized;
    Transform m_ParentTransform;
    float m_DefaultDistance;


    // Start is called before the first frame update
    void Start()
    {
        m_DefaultPos = transform.localPosition;
        m_DirectionNormalized = m_DefaultPos.normalized;
        m_ParentTransform = transform.parent;
        m_DefaultDistance = Vector3.Distance(m_DefaultPos, Vector3.zero);
    }
    private void LateUpdate()
    {
        Vector3 currentPosition = m_DefaultPos;
        RaycastHit hit;

        Vector3 tempDirection = m_ParentTransform.TransformPoint(m_DefaultPos) - m_ReferenceTransform.position;

        if(Physics.SphereCast(m_ReferenceTransform.position,m_CollisionOffset,tempDirection,out hit, m_DefaultDistance))
        {
            currentPosition = (m_DirectionNormalized * (hit.distance - m_CollisionOffset));
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, currentPosition, Time.deltaTime * 15f);
    }
}
