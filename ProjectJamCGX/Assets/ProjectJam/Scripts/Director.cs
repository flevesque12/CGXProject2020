using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour
{
    bool isSplashScreen = true;
    public Camera cam;
    public AudioSource audio;
    float timeInterval = 0f;
    public Image titlescreen;
    public GameObject character;
    private void Update()
    {

        if (isSplashScreen == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(FadeImage(true));
                cam.GetComponent<CameraControllerSmooth>().enabled = true;
                isSplashScreen = false;
                character.SetActive(true);

            }
        }

        if (audio.volume < .155 && Time.fixedTime + 1f >= timeInterval)
        {
            timeInterval = Time.fixedTime;
            audio.volume += .001f;
        }
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                titlescreen.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                titlescreen.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
