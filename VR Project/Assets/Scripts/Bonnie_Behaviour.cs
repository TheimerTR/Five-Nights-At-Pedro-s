using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonnie_Behaviour : MonoBehaviour
{
    public Light spotLight;
    public Animator anim;
    public GameObject bonnie;
    public AudioSource knok_knok;

    public float t_activate;
    public float t_deactivate;

    public bool canKill;

    // Start is called before the first frame update
    void Start()
    {
        knok_knok = GetComponent<AudioSource>();
        anim.SetBool("Open", false);

        spotLight.enabled = false;
        bonnie.SetActive(false);

        t_activate = 0;
        t_deactivate = 0;

        canKill = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (t_deactivate == 0)
        {
            t_activate += Time.deltaTime;
        }

        if (t_activate > 10f) 
        { 
            if(t_deactivate == 0f)
            {
                knok_knok.Play();
                bonnie.SetActive(true);
            }

            t_deactivate += Time.deltaTime;
        }

        if (t_deactivate > 5f)
        {
            anim.SetBool("Open", true);

            canKill = true;

            if (t_deactivate > 6.2f)
            {
                anim.SetBool("Open", false);
                canKill = false;
                t_activate = 0f;
                t_deactivate = 0f;
            }
        }
    }
}
