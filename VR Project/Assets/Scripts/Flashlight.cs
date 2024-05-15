using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool On;
    public bool deactivated;

    public Light spotlight;
    public GameObject colliderDetector;

    // Start is called before the first frame update
    void Start()
    {
        On = true;
        deactivated = false;
        colliderDetector.SetActive(true);
        spotlight.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (deactivated) 
        { 
            On =  false;
            spotlight.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!deactivated) { SwitchLight(); }
        }
    }

    public void SwitchLight()
    {
        if (!deactivated) 
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
}
