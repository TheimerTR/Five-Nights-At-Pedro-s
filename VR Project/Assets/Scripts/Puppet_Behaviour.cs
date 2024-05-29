using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SixAM;
using static UnityEngine.XR.OpenXR.Features.Interactions.DPadInteraction;

public class Puppet_Behaviour : MonoBehaviour
{
    public float speed;
    public float DownSpeed;

    public bool isBeeingPushed;
    public bool stopPushing;

    public bool puppetKill;

    public SixAM isHour;
    public AudioSource Jumpscare;

    bool dead = false;
    float passScene = 0f;
    public GameObject chica_Jumpscare;

    public bool isTutorial = false;

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
        if (!isTutorial)
        {
            if (isHour.currentHour != SixAM.Hour.SIX_AM)
            {
                if (dead)
                {
                    passScene += Time.deltaTime;

                    if (passScene > 1.5f)
                    {
                        SceneManager.LoadScene("Dead");
                    }
                }

                PushPuppet();

                if (puppetKill)
                {
                    dead = true;
                    chica_Jumpscare.SetActive(true);
                    Jumpscare.Play();
                    isBeeingPushed = false;
                    Debug.Log("DEAD");
                }
            }
        }

        else
        {
            PushPuppet();
        }
    }

    private void PushPuppet() // Puppet push logic
    {
        if (!isBeeingPushed && !stopPushing && !puppetKill)
            gameObject.transform.localPosition += new Vector3(0, speed * 0.00001f, 0);

        if (isBeeingPushed && !stopPushing && !puppetKill)
            gameObject.transform.localPosition += new Vector3(0, -DownSpeed * 0.00001f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (isHour.currentHour != SixAM.Hour.SIX_AM)
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

            if (other.tag == "PuppetKill")
            {
                puppetKill = true;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (isHour.currentHour != SixAM.Hour.SIX_AM)
        {
            if (other.tag != "StopPuppet" && other.tag != "Interactuables" && other.tag != "Foxy_FlashLight")
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

    }

    private void OnTriggerExit(Collider other)
    {
        if (isHour.currentHour != SixAM.Hour.SIX_AM)
        {
            if (other.tag != "StopPuppet" && other.tag != "Interactuables" && other.tag != "Foxy_FlashLight")
            {
                isBeeingPushed = false;
            }
        }
    }
}
