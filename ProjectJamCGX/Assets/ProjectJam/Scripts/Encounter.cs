using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    public int encounterid;
    public Animator anim;
    public GameObject nextLine;
    bool animActive = false;
    bool openingLineSaid = false;
    public BoxCollider bc;

    // Update is called once per frame
    void Update()
    {
        if (animActive == true)
        {
            if (Input.GetMouseButtonDown(0) && openingLineSaid == false)
            {
                anim.SetTrigger("Activate");
                openingLineSaid = true;
            }
            else if (Input.GetMouseButtonDown(0) && openingLineSaid == true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (bc.Raycast(ray, out hit, 100.0f))
                {
                    
                    nextLine.SetActive(true);
                    anim.SetTrigger("NextDialogueLine");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Character")
        {
            anim.gameObject.SetActive(true);
            anim.enabled = true;
        }
      
    }
}
