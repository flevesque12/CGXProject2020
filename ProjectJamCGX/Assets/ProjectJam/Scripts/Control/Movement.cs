using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 this is where we going to use physics(or charactercontroller) and animation update with animator
     */

public class Movement : MonoBehaviour
{
    Animator m_Animator;
    Rigidbody m_Rb;


    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
