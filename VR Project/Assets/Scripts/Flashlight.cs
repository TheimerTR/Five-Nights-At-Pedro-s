using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool On;

    public Light spotlight;
    public GameObject colliderDetector;

    // Start is called before the first frame update
    void Start()
    {
        On = true;
        colliderDetector.SetActive(true);
        spotlight.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchLight();
        }
    }

    public void SwitchLight()
    {
        On = !On;

        if (On)
        {
            colliderDetector.SetActive(true);
            spotlight.enabled = true;
        }
        else
        {
            colliderDetector.SetActive(false);
            spotlight.enabled = false;
        }
    }
}
