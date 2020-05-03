using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public Vector3 pos;
    public Transform t;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z) + t.position;
    }
}
