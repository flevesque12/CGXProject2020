using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBehaviour : MonoBehaviour
{
   
    bool isActive = false;
    private void Update()
    {
        if (isActive == false)
        {
            if (GetComponent<Animator>().isActiveAndEnabled == false)
            {
                GetComponent<Animator>().enabled = true;
                isActive = true;
            }
        }

    }
}
