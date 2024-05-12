using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppet_Behaviour : MonoBehaviour
{
    public float speed;
    public float DownSpeed;

    public bool isBeeingPushed;
    public bool stopPushing;

    public bool puppetKill;

    // Start is called before the first frame update
    void Start()
    {
        isBeeingPushed = false;
        stopPushing = false;
        puppetKill = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBeeingPushed && !stopPushing && !puppetKill)
            gameObject.transform.localPosition += new Vector3(0, speed * 0.00001f, 0);

        if (isBeeingPushed && !stopPushing && !puppetKill)
            gameObject.transform.localPosition += new Vector3(0, -DownSpeed * 0.00001f, 0);

        if (puppetKill)
        {
            isBeeingPushed = false;
            Debug.Log("DEAD");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StopPuppet")
        {
            if (isBeeingPushed)
            {
                stopPushing = true;
            }
            else
            {
                stopPushing = false;
            }
        }

        if(other.tag == "PuppetKill")
        {
            puppetKill = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag != "StopPuppet" && other.tag != "Interactuables")
        {
            isBeeingPushed = true;
        }

        if (isBeeingPushed)
        {
            if (other.tag == "StopPuppet")
            {
                stopPushing = true;
                isBeeingPushed = false;
            }
        }
        else
        {
            if (other.tag == "StopPuppet")
            {
                stopPushing = false;
                isBeeingPushed = false;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "StopPuppet" && other.tag != "Interactuables")
        {
            isBeeingPushed = false;
        }
    }
}
