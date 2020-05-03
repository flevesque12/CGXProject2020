using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogMovement : MonoBehaviour
{
    public float ScrollX = 0.025f;
    public float ScrollY = 0.005f;
 

    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * ScrollX;
        float offsetY = Time.time * ScrollY;
        GetComponent<Image>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
