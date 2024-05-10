using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SixAM : MonoBehaviour
{
    Animator anim;
    public bool win;

    AudioSource audio;

    public bool Zero_AM;
    public bool One_AM;
    public bool Two_AM;
    public bool Three_AM;
    public bool Four_AM;
    public bool Five_AM;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        win = false;

        Zero_AM = true;
        One_AM = false;
        Two_AM = false;
        Three_AM = false;
        Four_AM = false;
        Five_AM = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            audio.Play();
            Debug.Log("YOU WON!");

            win = false;
        }
    }

    public void isSixAM()
    {
        win = true;
    }

    public void isZeroAM() 
    {
        Zero_AM = true;
        One_AM = false;
        Two_AM = false;
        Three_AM = false;
        Four_AM = false;
        Five_AM = false;
    }
    public void isOneAM() 
    {
        Zero_AM = false;
        One_AM = true;
        Two_AM = false;
        Three_AM = false;
        Four_AM = false;
        Five_AM = false;
    }
    public void isTwoAM() 
    {
        Zero_AM = false;
        One_AM = false;
        Two_AM = true;
        Three_AM = false;
        Four_AM = false;
        Five_AM = false;
    }
    public void isThreeAM() 
    {
        Zero_AM = false;
        One_AM = false;
        Two_AM = false;
        Three_AM = true;
        Four_AM = false;
        Five_AM = false;
    }
    public void isFourAM() 
    {
        Zero_AM = false;
        One_AM = false;
        Two_AM = false;
        Three_AM = false;
        Four_AM = true;
        Five_AM = false;
    }
    public void isFiveAM() 
    {
        Zero_AM = false;
        One_AM = false;
        Two_AM = false;
        Three_AM = false;
        Four_AM = false;
        Five_AM = true;
    }
}
