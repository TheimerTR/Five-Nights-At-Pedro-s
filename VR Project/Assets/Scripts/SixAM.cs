using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Video;

public class SixAM : MonoBehaviour
{
    Animator anim;
    public bool win;

    public VideoPlayer tv;
    public VideoClip isSixAM_Video;

    public Light directionalLight;

    AudioSource audio;

    public bool Zero_AM;
    public bool One_AM;
    public bool Two_AM;
    public bool Three_AM;
    public bool Four_AM;
    public bool Five_AM;

    public GameObject rain;
    public AudioSource rainSound;
    public AudioSource AmbientSound;
    public AudioSource MusicSound;

    Color Night;
    Color Day;

    public float DayTimer = 0;

    public float TimeTransition;

    // Start is called before the first frame update
    void Start()
    {
        Night = new Color(0.09692062f, 0.1262041f, 0.2075472f, 1f);
        Day = new Color(0.8113208f, 0.6888272f, 0.4324493f, 1f);
        directionalLight.color = Night;

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
        if (Input.GetKeyDown(KeyCode.M))
        {
            win = true;
        }

        if (win)
        {
            tv.clip = isSixAM_Video;
            tv.SetDirectAudioVolume(0, 0);
            audio.Play();

            rain.SetActive(false);
            rainSound.Stop();
            AmbientSound.Stop();
            MusicSound.Stop();

            if(DayTimer < 1)
            {
                DayTimer += Time.deltaTime / TimeTransition;

                directionalLight.color = Color.Lerp(Night, Day, DayTimer);


                Debug.Log("YOU WON!");
            }

            if(DayTimer >= 1)
            {
                win = false;
            }
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
