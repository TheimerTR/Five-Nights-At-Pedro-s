using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.XR.OpenXR.Features.Interactions.DPadInteraction;
using UnityEngine.SceneManagement;

public class Bonnie_Behaviour : MonoBehaviour
{
    public SixAM isHour;

    public Light spotLight;
    public Animator anim;
    public GameObject bonnie;

    public AudioSource knok_knok;
    public AudioSource growl;
    public AudioSource jumpscare;

    public float t_activate;
    public float t_deactivate;

    public float time_to_activate = 0;

    public bool canKill;
    public bool isSave;

    bool dead = false;
    float passScene = 0f;
    public GameObject chica_Jumpscare;

    // Tutorial
    public bool isTutorial = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Open", false);

        spotLight.enabled = false;
        bonnie.SetActive(false);

        t_activate = 0;
        t_deactivate = 0;

        canKill = false;
        isSave = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTutorial)
        {
            if (isHour.currentHour != SixAM.Hour.SIX_AM) // normal behaviour
            {
                if (dead)
                {
                    passScene += Time.deltaTime;

                    if (passScene > 1.5f)
                    {
                        SceneManager.LoadScene("Dead");
                    }
                }

                switch (isHour.currentHour)
                {
                    case SixAM.Hour.ZERO_AM:
                        time_to_activate = 40f;
                        break;
                    case SixAM.Hour.ONE_AM:
                        time_to_activate = 30f;
                        break;
                    case SixAM.Hour.TWO_AM:
                        time_to_activate = 25f;
                        break;
                    case SixAM.Hour.THREE_AM:
                        time_to_activate = 20f;
                        break;
                    case SixAM.Hour.FOUR_AM:
                        time_to_activate = 15f;
                        break;
                    case SixAM.Hour.FIVE_AM:
                        time_to_activate = 12f;
                        break;
                    default:
                        break;
                }

                if (t_deactivate == 0)
                {
                    t_activate += Time.deltaTime;
                }

                if (t_activate > time_to_activate)
                {
                    if (t_deactivate == 0f)
                    {
                        knok_knok.Play();

                        bonnie.SetActive(true);
                    }

                    if (t_deactivate >= 0.5f && t_deactivate <= 0.7f)
                    {
                        growl.Play();
                    }

                    t_deactivate += Time.deltaTime;
                }

                if (t_deactivate > 5f)
                {
                    spotLight.enabled = true;

                    anim.SetBool("Open", true);

                    canKill = true;

                    if (t_deactivate > 5.02f)
                    {
                        if (!isSave)
                        {
                            //Debug.Log("YOU ARE DEAD");
                            dead = true;
                            chica_Jumpscare.SetActive(true);
                            jumpscare.Play();
                        }
                    }

                    if (t_deactivate > 6.2f)
                    {
                        anim.SetBool("Open", false);
                        spotLight.enabled = false;
                        canKill = false;
                        t_activate = 0f;
                        t_deactivate = 0f;
                    }
                }
            }
        }

        else
        {
            time_to_activate = 2.5f;

            if (t_deactivate == 0)
            {
                t_activate += Time.deltaTime;
            }

            if (t_activate > time_to_activate)
            {
                if (t_deactivate == 0f)
                {
                    knok_knok.Play();

                    bonnie.SetActive(true);
                }

                if (t_deactivate >= 0.5f && t_deactivate <= 0.7f)
                {
                    growl.Play();
                }

                t_deactivate += Time.deltaTime;
            }

            if (t_deactivate > 5f)
            {
                spotLight.enabled = true;

                anim.SetBool("Open", true);

                canKill = true;

                if (t_deactivate > 8.02f)
                {
                    if (!isSave && !isTutorial)
                    {
                        // Don't kill with tutorial, but jumpscare to learn
                        Debug.Log("YOU ARE DEAD Bonnie");
                        dead = true; 
                        chica_Jumpscare.SetActive(true); // chica?
                        jumpscare.Play();
                        t_deactivate = 0;
                        t_activate = 0f;
                    }
                }

                if (t_deactivate > 9.2f)
                {
                    anim.SetBool("Open", false);
                    spotLight.enabled = false;
                    canKill = false;
                    t_activate = 0f;
                    t_deactivate = 0f;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isHour.currentHour != SixAM.Hour.SIX_AM)
        {
            if (canKill)
            {
                if (other.tag == "Player")
                {
                    Debug.Log("YOU ARE SAVE");
                    isSave = true;

                    if (isTutorial)
                    {
                        GameObject welldone = GameObject.Find("CongratsSoundEffect");
                        AudioSource congrats = welldone.GetComponent<AudioSource>();
                        congrats.Play();

                        player.GetComponent<TrackTutorials>().UpdateTutorials();
                        this.enabled = false;
                        this.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isHour.currentHour != SixAM.Hour.SIX_AM)
        {
            isSave = false;
        }
    }
}
