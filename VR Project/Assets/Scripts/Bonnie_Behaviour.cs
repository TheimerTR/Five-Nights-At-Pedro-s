using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        if (isHour.currentHour == SixAM.Hour.ZERO_AM)
        {
            time_to_activate = 40f;
        }
        
        if (isHour.currentHour == SixAM.Hour.ONE_AM)
        {
            time_to_activate = 30f;
        } 
        
        if (isHour.currentHour == SixAM.Hour.TWO_AM)
        {
            time_to_activate = 25f;
        }
        
        if (isHour.currentHour == SixAM.Hour.THREE_AM)
        {
            time_to_activate = 20f;
        }
        
        if (isHour.currentHour == SixAM.Hour.FOUR_AM)
        {
            time_to_activate = 15f;
        }
        
        if (isHour.currentHour == SixAM.Hour.FIVE_AM)
        {
            time_to_activate = 10f;
        }

        if (t_deactivate == 0)
        {
            t_activate += Time.deltaTime;
        }

        if (t_activate > time_to_activate) 
        { 
            if(t_deactivate == 0f)
            {
                knok_knok.Play();

                bonnie.SetActive(true);
            }

            if(t_deactivate >= 0.5f && t_deactivate <= 0.7f)
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

            if (t_deactivate > 5.1f)
            {
                if (!isSave)
                {
                    //Debug.Log("YOU ARE DEAD");
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

    private void OnTriggerStay(Collider other)
    {
        if (canKill)
        {
            if (other.tag == "Player")
            {
                //Debug.Log("YOU ARE SAVE");
                isSave = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isSave = false;
    }
}
