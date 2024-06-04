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

    public float time_to_activate = 0; //Variable para el tutorial
    public List<float> timeToAppear; //Tiempo que tarda en empezar a picar a la puerta

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
                //If Bonny killed you, transition to dead scene
                if (dead)
                {
                    passScene += Time.deltaTime;

                    if (passScene > 1.5f)
                    {
                        SceneManager.LoadScene("Dead");
                    }
                }

                if (t_deactivate == 0)
                {
                    t_activate += Time.deltaTime;
                }

                //Start timer to hide behind the door
                if (t_activate > timeToAppear[(int)isHour.currentHour])
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

                //If not hiden you will die
                if (t_deactivate > 8f)
                {
                    spotLight.enabled = true;
                    knok_knok.volume -= 1.3f;

                    anim.SetBool("Open", true);

                    canKill = true;

                    if (t_deactivate > 8.02f)
                    {
                        if (!isSave)
                        {
                            //Debug.Log("YOU ARE DEAD");
                            dead = true;
                            Debug.Log("YOU ARE DEAD Bonnie");
                            chica_Jumpscare.SetActive(true);
                            jumpscare.Play();
                            t_deactivate = 0;
                            t_activate = 0f;
                        }
                    }

                    if (t_deactivate > 9.2f && !dead)
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
            time_to_activate = 5f;

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

                //if (t_deactivate >= 2f && t_deactivate <= 2.2f)
                //{
                //    knok_knok.volume += 0.5f;
                //    knok_knok.Play();
                //    //knok_knok.volume -= 0.5f;
                //}

                //if (t_deactivate >= 5f && t_deactivate <= 5.2f)
                //{
                //    knok_knok.volume += 0.8f;
                //    knok_knok.Play();
                //    //knok_knok.volume -= 0.8f;
                //}

                t_deactivate += Time.deltaTime;
            }

            if (t_deactivate > 5f)
            {
                spotLight.enabled = true;

                anim.SetBool("Open", true);

                canKill = true;

                if (t_deactivate > 5.02f)
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

    private void OnTriggerStay(Collider other)
    {
        if (isHour.currentHour != SixAM.Hour.SIX_AM)
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

    private void OnTriggerExit(Collider other)
    {
        if (isHour.currentHour != SixAM.Hour.SIX_AM)
        {
            Debug.Log("YOU ARE NOT SAVE");
            isSave = false;
        }
    }
}
